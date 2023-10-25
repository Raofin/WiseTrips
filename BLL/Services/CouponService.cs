using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL.Services;

public class CouponService : ICouponService
{
    private readonly IMapper _mapper;
    private readonly ICouponRepo _couponRepo;

    public CouponService(IMapper mapper, DataAccessFactory dataAccessFactory)
    {
        _mapper = mapper;
        _couponRepo = dataAccessFactory.CouponDataAccess();
    }

    public async Task<List<CouponDto>> GetAsync()
    {
        var coupons = await _couponRepo.GetAsync();
        return _mapper.Map<List<CouponDto>>(coupons);
    }

    public async Task<CouponDto> GetAsync(int id)
    {
        var coupon = await _couponRepo.GetAsync(id);
        return _mapper.Map<CouponDto>(coupon);
    }

    public async Task<bool> AddAsync(CouponDto dto)
    {
        var data = _mapper.Map<Coupon>(dto);
        var result = await _couponRepo.AddAsync(data);
        return result;
    }

    public async Task UpdateAsync(CouponDto coupon)
    {
        var data = _mapper.Map<Coupon>(coupon);
        await _couponRepo.UpdateAsync(data);
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}