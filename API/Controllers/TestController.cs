using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TestController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Test()
        {
            var data = UserService.Get();
            return Ok(data);
        }
    }
}