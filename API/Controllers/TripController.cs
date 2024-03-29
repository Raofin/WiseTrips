﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using API.Auth;
using BLL.DTOs;
using BLL.Services;

namespace API.Controllers
{
    [LoggedIn]
    public class TripController : ApiController
    {
        [HttpGet]
        [Route("api/trips")]
        public HttpResponseMessage GetTrips()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TripService.GetAll());
        }

        [HttpGet]
        [Route("api/trips/{id}")]
        public HttpResponseMessage GetTrip(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, TripService.Get(id));
        }

        [HttpPost]
        [Route("api/trip/add")]
        public HttpResponseMessage AddTrip(TripDto tripDto)
        {
            var user = UserService.GetByToken(Request.Headers.Authorization.ToString());
            tripDto.UserId = user.Id;

            var trip = TripService.Add(tripDto);

            return Request.CreateResponse(HttpStatusCode.OK, trip);
        }
    }
}