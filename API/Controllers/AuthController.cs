using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var token = await _authService.AuthenticateAsync(loginDto.Username, loginDto.Password);
        if (token != null)
        {
            return Ok(token);
        }
        return NotFound();
    }

    [HttpGet("logout")]
    public async Task<IActionResult> LogoutAsync()
    {
        var authToken = Request.Headers["Authorization"].ToString();

        if (await _authService.LogoutAsync(authToken))
        {
            return Ok("Successfully logged out.");
        }
        return BadRequest("Invalid token");
    }
}