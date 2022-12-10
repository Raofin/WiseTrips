﻿using System;
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
        public static IRepo<User, int, bool> UserDataAccess()      //For user repo
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

        public static IRepo<Coupon, int, bool> CouponDataAccess()         //For coupon repo
        {
            return new CouponRepo();
        }

        public static IRepo<Agency, int, bool> AgencyDataAccess()         //For coupon repo
        {
            return new AgencyRepo();
        }

    }
}
