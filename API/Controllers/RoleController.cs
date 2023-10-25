using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        /*[HttpGet]
        public IActionResult GetRoles()
        {
            return Ok(RoleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            return Ok(RoleService.Get(id));
        }

        [HttpPost("add")]
        public IActionResult AddRole(RoleDto roleDto)
        {
            var role = RoleService.Add(roleDto);
            return Ok(role);
        }

        [HttpPost("update")]
        public IActionResult UpdateRole(RoleDto roleDto)
        {
            var role = RoleService.Update(roleDto);
            return Ok(role);
        }*/
    }
}