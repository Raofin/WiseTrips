using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Auth;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/packages")]
    [LoggedIn]
    public class PackageController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = PackageService.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = PackageService.Get(id);
            return Ok(data);
        }

        [HttpPost("add")]
        public IActionResult Add(PackageDto package)
        {
            var data = PackageService.Add(package);

            if (data != null)
            {
                return Ok(data);
            }
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(int id, PackageDto package)
        {
            PackageService.Update(package);
            return Ok();
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = PackageService.Delete(id);

            if (data)
            {
                return Ok("deleted");
            }
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}