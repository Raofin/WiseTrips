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
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("logged-in-user")]
        public async Task<IActionResult> GetLoggedInUser()
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var user = await _userService.GetByTokenAsync(authorizationHeader);
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto, [FromQuery] string role)
        {
            var user = await _userService.RegisterAsync(userDto, role);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
        {
            await _userService.UpdateAsync(userDto);
            return Ok(true);
        }
    }
}