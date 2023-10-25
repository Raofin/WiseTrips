using API.Auth;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/trips")]
[LoggedIn]
public class TripController : ControllerBase
{
    private readonly ITripService _tripService;
    private readonly IUserService _userService;

    public TripController(ITripService tripService, IUserService userService)
    {
        _tripService = tripService;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        var trips = await _tripService.GetAsync();
        return Ok(trips);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrip(int id)
    {
        var trip = await _tripService.GetAsync(id);
        if (trip == null)
        {
            return NotFound();
        }
        return Ok(trip);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddTrip([FromBody] TripDto tripDto)
    {
        var authorizationHeader = Request.Headers["Authorization"].ToString();
        var user = await _userService.GetByTokenAsync(authorizationHeader);

        if (user == null)
        {
            return Unauthorized();
        }

        tripDto.UserId = user.Id;
        var trip = await _tripService.AddAsync(tripDto);

        return Ok(trip);
    }
}