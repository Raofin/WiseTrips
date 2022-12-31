using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.Services;

namespace API.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Test()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}