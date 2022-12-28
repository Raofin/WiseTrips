using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.DTOs;
using BLL.Services;

namespace App.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginDto loginDto)
        {
            var data = AuthService.Authenticate(loginDto.Username, loginDto.Password);

            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var authToken = Request.Headers.Authorization.ToString();

            if (AuthService.Logout(authToken))
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Successfully logged out.");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid token");
        }
    }
}
