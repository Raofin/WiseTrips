using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using App.Auth;

namespace App.Controllers
{
    [LoggedIn]
    [EnableCors("*", "*", "*")]
    public class PackageController : ApiController
    {
        [HttpGet]
        [Route("api/packages")]
        public HttpResponseMessage Get()
        {
            var data = PackageService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/package/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = PackageService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        
        [HttpPost]
        [Route("api/packages/add")]
        public HttpResponseMessage Add(PackageDto package)
        {
            var data = PackageService.Add(package);
            
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
        
        [HttpGet]
        [Route("api/packages/update/{id}")]
        public HttpResponseMessage Update(PackageDto package)
        {
            PackageService.Update(package);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/packages/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = PackageService.Delete(id);

            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "deleted");
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}