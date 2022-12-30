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
    public class AgencyController : ApiController
    {
        [HttpGet]
        [Route("api/agencies")]
        public HttpResponseMessage Get()
        {
            var data = AgencyService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/agencies/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = AgencyService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/agencies/add")]
        public HttpResponseMessage Add(AgencyDto agency)
        {
            var data = AgencyService.Add(agency);

            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        [Route("api/agencies/update/{id}")]
        public HttpResponseMessage Update(AgencyDto agency)
        {
            AgencyService.Update(agency);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/agencies/delete/{id}")]
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
