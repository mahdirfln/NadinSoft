using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NadinSoft.Domain.Entities;
using MediatR;
using NadinSoft.Application.CommandsQueries.User.Queries;

namespace NadinSoft.Presentation.Api.Helpers
{
    [AttributeUsage(AttributeTargets.All)]
    public class CusttomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (int?)context.HttpContext.Items["User"];
            if (user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
