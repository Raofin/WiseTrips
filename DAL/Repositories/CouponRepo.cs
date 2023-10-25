using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CouponRepo : ICouponRepo
    {
        private readonly WiseTripsContext _context;

        public CouponRepo(WiseTripsContext context)
        {
            _context = context;
        }

        public  bool Add(Coupon obj)
        {
            _context.Coupons.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            _context.Coupons.Remove(_context.Coupons.Find(id));
            return _context.SaveChanges()>0;
        }

        public List<Coupon> Get()
        {
            return _context.Coupons.ToList();
        }

        public Coupon Get(int id)
        {
            return _context.Coupons.Find(id);
        }

        public bool Update(Coupon obj)
        {
            var ext = Get(obj.Id);
            _context.Entry(ext).CurrentValues.SetValues(obj);
            return _context.SaveChanges() > 0;
        }

        bool ICrudRepo<Coupon, int, bool>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
