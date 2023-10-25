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
    [Route("api/agencies")]
    public class AgencyController : ControllerBase
    {
        /*[HttpGet]
        public IActionResult Get()
        {
            var data = AgencyService.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = AgencyService.Get(id);
            return Ok(data);
        }

        [HttpPost("add")]
        public IActionResult Add(AgencyDto agency)
        {
            *//*var data = AgencyService.Add(agency);

            if (data != null)
            {
                return Ok(data);
            }
            return StatusCode((int)HttpStatusCode.InternalServerError);*//*
            return null;
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(int id, AgencyDto agency)
        {
            AgencyService.Update(agency);
            return Ok();
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = AgencyService.Delete(id);

            if (data != false)
            {
                return Ok("deleted");
            }
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }*/
    }
}