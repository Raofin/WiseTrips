using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class DataAccessFactory
    {
        private readonly WiseTripsContext _context;

        public DataAccessFactory(WiseTripsContext context)
        {
            _context = context;
        }

        public IUserRepo UserDataAccess()
        {
            return new UserRepo(_context);
        }

        public IAuthRepo AuthDataAccess()
        {
            return new UserRepo(_context);
        }

        public IToken TokenDataAccess()
        {
            return new TokenRepo(_context);
        }

        public ICouponRepo CouponDataAccess()
        {
            return new CouponRepo(_context);
        }

        public IAgencyRepo AgencyDataAccess()
        {
            return new AgencyRepo(_context);
        }

        public IPackageRepo PackageDataAccess()
        {
            return new PackageRepo(_context);
        }

        public ITripRepo TripDataAccess()
        {
            return new TripRepo(_context);
        }

        public IHotelRepo HotelDataAccess()
        {
            return new HotelRepo(_context);
        }

        public IRoleRepo RoleDataAccess()
        {
            return new RoleRepo(_context);
        }
    }
}