using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Auth;
using Azure.Core;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(UserService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(UserService.Get(id));
        }

        [HttpGet("logged-in-user")]
        public IActionResult GetLoggedInUser()
        {
            var user = UserService.GetByToken(Request.Headers["Authorization"].ToString());
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult AddUser(UserDto userDto, string role)
        {
            var user = UserService.Register(userDto, role);
            return Ok(user);
        }

        [HttpPost("update")]
        public IActionResult UpdateUser(UserDto userDto)
        {
            UserService.Update(userDto);
            return Ok(true);
        }
    }
}