using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CouponRepo : ICouponRepo
{
    private readonly WiseTripsContext _context;

    public CouponRepo(WiseTripsContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Coupon obj)
    {
        _context.Coupons.Add(obj);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var coupon = await GetAsync(id);
        if (coupon != null)
        {
            _context.Coupons.Remove(coupon);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<List<Coupon>> GetAsync()
    {
        return await _context.Coupons.ToListAsync();
    }

    public async Task<Coupon> GetAsync(int id)
    {
        return await _context.Coupons.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(Coupon obj)
    {
        var existingCoupon = await GetAsync(obj.Id);
        if (existingCoupon != null)
        {
            _context.Entry(existingCoupon).CurrentValues.SetValues(obj);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }
}