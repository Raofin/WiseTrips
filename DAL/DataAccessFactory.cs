using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, bool> UserDataAccess()
        {
            return new UserRepo();
        }

        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }

        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }

        public static IRepo<Coupon, int, bool> CouponDataAccess()
        {
            return new CouponRepo();
        }

        public static IRepo<Agency, int, Agency> AgencyDataAccess()
        {
            return new AgencyRepo();
        }

        public static IRepo<Package, int, Package> PackageDataAccess()
        {
            return new PackageRepo();
        }

        public static IRepo<Trip, int, bool> TripDataAccess()
        {
            return new TripRepo();
        }

        public static IRepo<Hotel, int, bool> HotelDataAccess()
        {
            return new HotelRepo();
        }

        public static IRepo<Role, int, bool> RoleDataAccess()
        {
            return new RoleRepo();
        }
    }
}