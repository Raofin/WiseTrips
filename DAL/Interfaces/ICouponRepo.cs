using DAL.Entity;

namespace DAL.Interfaces;

public interface ICouponRepo : ICrudRepo<Coupon, int, bool>
{
}