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
    public class AdminController : ApiController
    {
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/users/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/users/add")]
        [HttpPost]
        public HttpResponseMessage Add(UserDto user)  //user
        {


            var data = UserService.Add(user);      //user
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/users/delete/{ID}")]      
        [HttpDelete]
        public HttpResponseMessage Delete(int ID)  //user
        {


            UserService.Delete(ID);      //user
                                         // if (data)
                                         // {
            return Request.CreateResponse(HttpStatusCode.OK);
            //   }
            //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
            //}


        }
        [Route("api/users/update")]         //user update done
        [HttpPost]
        public HttpResponseMessage Update(UserDto user)  //user
        {


             UserService.Update(user);      //user
                                                      //    if (data)
                                                      //    {
                                                              return Request.CreateResponse(HttpStatusCode.OK);
                                                      //    }
                                                      //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                                                      //}

        }
    }
}