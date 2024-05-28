using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NadinSoft.Application.CommandsQueries.User.Queries;
using NadinSoft.Application.Interfaces.Repositories;
using NadinSoft.Domain.Entities;
using NadinSoft.Presentation.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace NadinSoft.Presentation.Api.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private IMediator _mediator;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IMediator mediator)
        {
            _mediator = mediator;

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await attachUserToContext(context, token);

            await _next(context);
        }

        private async Task attachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var username = jwtToken.Claims.First(x => x.Type == "username").Value;
                var password = jwtToken.Claims.First(x => x.Type == "password").Value;

                //Attach user to context on successful JWT validation
                var request = new GetUser();

                request.UserName = username;
                request.Password = password;

                //var user = _userRepository.Table().FirstOrDefault(u => u.UserName == "username" && u.Password == "password");

                var user = await _mediator.Send(request);
                if (user != null)
                    context.Items["User"] = user.Id;
            }
            catch
            {
                //JWT failed
            }
        }
    }
}