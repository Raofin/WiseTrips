using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CouponService
    {
        public static List<CouponDto> Get()
        {
            var coupons = DataAccessFactory.CouponDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponDto>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CouponDto>>(coupons);
            return data;
        }

        public static CouponDto Get(int id)
        {
            var coupon = DataAccessFactory.CouponDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponDto>());
            var mapper = new Mapper(config);
            var data = mapper.Map<CouponDto>(coupon);
            return data;
        }

        public static bool Add(CouponDto dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Coupon, CouponDto>();
                cfg.CreateMap<CouponDto, Coupon>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<Coupon>(dto);
            var result = DataAccessFactory.CouponDataAccess().Add(data);
            return result;
        }

        public static void Update(CouponDto coupon)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CouponDto, Coupon>();
                cfg.CreateMap<Coupon, CouponDto>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Coupon>(coupon);
            DataAccessFactory.CouponDataAccess().Update(data);
        }
    }
}
