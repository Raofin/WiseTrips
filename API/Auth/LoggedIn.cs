using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using BLL.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace API.Auth
{
    public class LoggedInAttribute : TypeFilterAttribute
    {
        public LoggedInAttribute() : base(typeof(LoggedInFilter)) { }
    }

    public class LoggedInFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedObjectResult("No token supplied");
            }
            else if (!AuthService.TokenValidity(token))
            {
                context.Result = new UnauthorizedObjectResult("Supplied token is invalid or expired");
            }
        }
    }
}
