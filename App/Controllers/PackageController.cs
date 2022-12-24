using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace App.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PackageController : ApiController
    {
        [Route("api/packages")]

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = PackageService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/packages/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = PackageService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/packages/add")]
        [HttpPost]
        public HttpResponseMessage Add(PackageDto package)
        {


            var data = PackageService.Add(package);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
        [Route("api/packages/update/{id}")]
        [HttpGet]
        public HttpResponseMessage Update(PackageDto package)
        {


            PackageService.Update(package);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [Route("api/packages/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {


            var data = PackageService.Delete(id);
            if (data != false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "deleted");
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}