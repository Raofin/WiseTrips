using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace App.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginDto loginDto)
        {
            var data = AuthService.Authenticate(loginDto.Username, loginDto.Password);

            return data != null
                ? Request.CreateResponse(HttpStatusCode.OK, data)
                : Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage Register(UserDto userDto)
        {
            return UserService.Add(userDto)
                ? Request.CreateResponse(HttpStatusCode.OK, "Registration Successful")
                : Request.CreateResponse(HttpStatusCode.PreconditionFailed);
        }
    }
}
