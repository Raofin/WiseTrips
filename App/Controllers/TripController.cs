using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using App.Auth;
using BLL.DTOs;
using BLL.Services;

namespace App.Controllers
{
    /*[LoggedIn]*/
    [EnableCors("*", "*", "*")]
    public class TripController : ApiController
    {
        [HttpGet]
        [Route("api/trips")]
        public HttpResponseMessage GetTrips()
        {
            /*var trips = new ArrayList();

            foreach (var trip in TripService.GetAll())
            {
                trips.Add(trip.Id);
                trips.Add(UserService.Get(trip.UserId));
                trips.Add(PackageService.Get(trip.PackageId));
                trips.Add(HotelService.Get(trip.HotelId));
                trips.Add(trip.Persons);
                trips.Add(trip.Date);
                if (trip.UsedCoupon == null)
                    trips.Add("No Coupon Applied");
                else
                {
                    trips.Add(CouponService.Get((int)trip.UsedCoupon));
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, trips);*/
            return Request.CreateResponse(HttpStatusCode.OK, TripService.GetAll());
        }

        [HttpGet]
        [Route("api/trips/{id}")]
        public HttpResponseMessage GetTrip(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, TripService.Get(id));
        }

        [HttpPost]
        [Route("api/trips/add")]
        public HttpResponseMessage AddTrip(TripDto tripDto)
        {
            var project = TripService.Add(tripDto);
            return Request.CreateResponse(HttpStatusCode.OK, project);
        }
    }
}
