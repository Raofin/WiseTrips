using API.Auth;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/roles")]
[LoggedIn]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        var roles = await _roleService.GetAsync();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRole(int id)
    {
        var role = await _roleService.GetAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddRole([FromBody] RoleDto roleDto)
    {
        var role = await _roleService.AddAsync(roleDto);
        if (role == null)
        {
            return BadRequest();
        }
        return Ok(role);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateRole([FromBody] RoleDto roleDto)
    {
        await _roleService.UpdateAsync(roleDto);
        return Ok(roleDto);
    }
}