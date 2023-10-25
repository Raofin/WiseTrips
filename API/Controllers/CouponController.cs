using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace API.Controllers
{
    [Route("api/coupons")]
    public class CouponController : ControllerBase
    {
        /*[HttpGet]
        public IActionResult Get()
        {
            var data = CouponService.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = CouponService.Get(id);
            return Ok(data);
        }

        [HttpPost("add")]
        public IActionResult Add(CouponDto coupon)
        {
            var data = CouponService.Add(coupon);

            if (data)
            {
                return Ok(data);
            }
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPost("update")]
        public IActionResult Update(CouponDto coupon)
        {
            CouponService.Update(coupon);
            return Ok();
        }*/
    }
}