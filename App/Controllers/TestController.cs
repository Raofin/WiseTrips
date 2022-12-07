using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;

namespace App.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Test()
        {
            var data = UserService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
