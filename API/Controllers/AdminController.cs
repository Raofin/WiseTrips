using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdminController : ControllerBase
    {
        [HttpGet]
        [Route("api/admin/users")]
        public IActionResult Get()
        {
            var data = UserService.Get();
            return Ok(data);
        }

        [HttpGet]
        [Route("api/admin/users/{id}")]
        public IActionResult Get(int id)
        {
            var data = UserService.Get(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("api/admin/users/add")]
        public IActionResult Add(UserDto user)
        {
            var data = UserService.Add(user);

            if (data)
            {
                return Ok(data);
            }
            return Ok(HttpStatusCode.InternalServerError);
        }

        [HttpDelete]
        [Route("api/admin/users/delete/{id}")]
        public IActionResult Delete(int id)
        {
            UserService.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("api/admin/users/update")]
        public IActionResult Update(UserDto user)
        {
            UserService.Update(user);
            return Ok();
        }
    }
}