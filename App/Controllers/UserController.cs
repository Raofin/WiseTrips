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
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage GetUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.Get());
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public HttpResponseMessage GetUser(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.Get(id));
        }

        [HttpGet]
        [Route("api/get-user")]
        public HttpResponseMessage GetUser(string token)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.GetByToken(token));
        }

        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage AddUser(UserDto userDto, string role)
        {
            var user = UserService.Register(userDto, role);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("api/update")]
        public HttpResponseMessage UpdateUser(UserDto userDto)
        {
            UserService.Update(userDto);
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}
