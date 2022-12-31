using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.DTOs;
using BLL.Services;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RoleController : ApiController
    {
        [HttpGet]
        [Route("api/roles")]
        public HttpResponseMessage GetRoles()
        {
            return Request.CreateResponse(HttpStatusCode.OK, RoleService.GetAll());
        }

        [HttpGet]
        [Route("api/roles/{id}")]
        public HttpResponseMessage GetRole(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, RoleService.Get(id));
        }

        [HttpPost]
        [Route("api/roles/add")]
        public HttpResponseMessage AddRole(RoleDto roleDto)
        {
            var role = RoleService.Add(roleDto);
            return Request.CreateResponse(HttpStatusCode.OK, role);
        }

        [HttpPost]
        [Route("api/roles/update")]
        public HttpResponseMessage UpdateRole(RoleDto roleDto)
        {
            var role = RoleService.Update(roleDto);
            return Request.CreateResponse(HttpStatusCode.OK, role);
        }
    }
}