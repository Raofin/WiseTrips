using System.Net;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/hotels")]
public class HotelController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var hotels = await _hotelService.GetAsync();
        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var hotel = await _hotelService.GetAsync(id);
        if (hotel == null)
        {
            return NotFound();
        }
        return Ok(hotel);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] HotelDto hotelDto)
    {
        var addedHotel = await _hotelService.AddAsync(hotelDto);
        if (addedHotel != null)
        {
            return Ok(addedHotel);
        }
        return StatusCode((int)HttpStatusCode.InternalServerError);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] HotelDto hotelDto)
    {
        await _hotelService.UpdateAsync(hotelDto);
        return Ok();
    }
}