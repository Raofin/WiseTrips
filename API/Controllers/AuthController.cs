using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Azure.Core;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var data = AuthService.Authenticate(loginDto.Username, loginDto.Password);

            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            var authToken = Request.Headers["Authorization"].ToString();

            if (AuthService.Logout(authToken))
            {
                return Ok("Successfully logged out.");
            }
            return BadRequest("Invalid token");
        }
    }
}