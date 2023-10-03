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
    [Route("api/hotels")]
    public class HotelController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHotels()
        {
            return Ok(HotelService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetHotel(int id)
        {
            return Ok(HotelService.Get(id));
        }

        [HttpPost("add")]
        public IActionResult AddHotel(HotelDto hotelDto)
        {
            var hotel = HotelService.Add(hotelDto);
            return Ok(hotel);
        }

        [HttpPost("update")]
        public IActionResult UpdateHotel(HotelDto hotelDto)
        {
            var hotel = HotelService.Update(hotelDto);
            return Ok(hotel);
        }
    }
}