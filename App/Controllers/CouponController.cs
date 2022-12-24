using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace App.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CouponController : ApiController
    {
        [Route("api/coupons")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = CouponService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/coupons/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = CouponService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/coupons/add")]
        [HttpPost]
        public HttpResponseMessage Add(CouponDto coupon)
        {


            var data = CouponService.Add(coupon);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);


        }
        [Route("api/coupons/update")]
        [HttpPost]
        public HttpResponseMessage Update(CouponDto coupon)  //coupon
        {


            CouponService.Update(coupon);      //user
                                             //    if (data)
                                             //    {
            return Request.CreateResponse(HttpStatusCode.OK);
            //    }
            //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
            //}
        }
    }
}
