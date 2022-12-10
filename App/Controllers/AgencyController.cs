using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App.Controllers
{
    public class AgencyController : ApiController
    {
        [Route("api/agencies")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AgencyService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/agencies/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = AgencyService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/agencies/add")]
        [HttpPost]
        public HttpResponseMessage Add(AgencyDto agency)
        {


            var data = AgencyService.Add(agency);
            if (data != false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
        [Route("api/agencies/update/{id}")]
        [HttpGet]
        public HttpResponseMessage Update(AgencyDto agency)
        {


            AgencyService.Update(agency);
            return Request.CreateResponse(HttpStatusCode.OK);
           
        }
        [Route("api/agencies/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {


            var data = AgencyService.Delete(id);
            if (data != false)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "deleted");
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
