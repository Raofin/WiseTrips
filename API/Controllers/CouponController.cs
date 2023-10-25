using System.Net;
using API.Auth;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/coupons")]
[LoggedIn]
public class CouponController : ControllerBase
{
    private readonly ICouponService _couponService;

    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var coupons = await _couponService.GetAsync();
        return Ok(coupons);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var coupon = await _couponService.GetAsync(id);
        if (coupon == null)
        {
            return NotFound();
        }
        return Ok(coupon);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CouponDto couponDto)
    {
        var added = await _couponService.AddAsync(couponDto);
        if (added)
        {
            return Ok(couponDto);
        }
        return StatusCode((int)HttpStatusCode.InternalServerError);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] CouponDto couponDto)
    {
        await _couponService.UpdateAsync(couponDto);

        return Ok();
    }
}