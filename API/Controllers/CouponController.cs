using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CouponController : ApiController
    {
        [HttpGet]
        [Route("api/coupons")]
        public HttpResponseMessage Get()
        {
            var data = CouponService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/coupons/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = CouponService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/coupons/add")]
        public HttpResponseMessage Add(CouponDto coupon)
        {
            var data = CouponService.Add(coupon);

            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [Route("api/coupons/update")]
        public HttpResponseMessage Update(CouponDto coupon)
        {
            CouponService.Update(coupon);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}