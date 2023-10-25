using System.Net;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/admin/users")]
public class AdminController : ControllerBase
{
    private readonly IUserService _userService;

    public AdminController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _userService.GetAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _userService.GetAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] UserDto userDto)
    {
        var addedUser = await _userService.AddAsync(userDto);
        if (addedUser)
        {
            return Ok(addedUser);
        }
        return StatusCode((int)HttpStatusCode.InternalServerError);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _userService.DeleteAsync(id);
        if (deleted)
        {
            return Ok("Deleted");
        }
        return StatusCode((int)HttpStatusCode.InternalServerError);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UserDto userDto)
    {
        await _userService.UpdateAsync(userDto);
        return Ok();
    }
}