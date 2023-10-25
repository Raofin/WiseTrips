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
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(_userService.Get(id));
        }

        [HttpGet("logged-in-user")]
        public IActionResult GetLoggedInUser()
        {
            var user = _userService.GetByToken(Request.Headers["Authorization"].ToString());
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult AddUser(UserDto userDto, string role)
        {
            var user = _userService.Register(userDto, role);
            return Ok(user);
        }

        [HttpPost("update")]
        public IActionResult UpdateUser(UserDto userDto)
        {
            _userService.Update(userDto);
            return Ok(true);
        }
    }
}