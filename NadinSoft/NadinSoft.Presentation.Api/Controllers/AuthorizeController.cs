using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NadinSoft.Application.CommandsQueries.User.Queries;
using NadinSoft.Domain.Entities;
using NadinSoft.Presentation.Api.Helpers;
using NadinSoft.Presentation.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NadinSoft.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthorizeController(IOptions<AppSettings> appSettings,
            IMediator mediator,
            IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetToken")]
        public async Task<string> GetToken(string username, string password)
        {
            var request = new GetUser();

            request.UserName = username;
            request.Password = password;

            var user = await _mediator.Send(request);
            if (user == null)
                return "username or password is incorect";

            var userModel = _mapper.Map<User>(user);
            var token = await generateJwtToken(userModel);

            return token;
        }

        private async Task<string> generateJwtToken(User user)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { 
                        new Claim("id", user.Id.ToString()),
                        new Claim("username", user.UserName.ToString()), 
                        new Claim("password", user.Password.ToString()) 
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }
    }
}
