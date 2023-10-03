using System;
using System.Collections;
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
    [Route("api/trips")]
    [LoggedIn]
    public class TripController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTrips()
        {
            return Ok(TripService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetTrip(int id)
        {
            return Ok(TripService.Get(id));
        }

        [HttpPost("add")]
        public IActionResult AddTrip(TripDto tripDto)
        {
            var user = UserService.GetByToken(Request.Headers["Authorization"].ToString());
            tripDto.UserId = user.Id;

            var trip = TripService.Add(tripDto);

            return Ok(trip);
        }
    }
}