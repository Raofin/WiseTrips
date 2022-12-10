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
            var dbdata = DataAccessFactory.CouponDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponDto>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CouponDto>>(dbdata);  //List convert data by list
            return data;
        
        }
        public static CouponDto Get(int id)
        {
            var dbdata = DataAccessFactory.CouponDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponDto>());
            var mapper = new Mapper(config);
            var data = mapper.Map<CouponDto>(dbdata);  //List convert data by list
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
            var data = mapper.Map<Coupon>(dto);               //List convert data by list
            var result = DataAccessFactory.CouponDataAccess().Add(data);
            //var redata = mapper.Map<CouponDto>(result);
            return result;
        }
        public static void Update(CouponDto coupon)       //coupon
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CouponDto, Coupon>();
                cfg.CreateMap<Coupon, CouponDto>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Coupon>(coupon);
            DataAccessFactory.CouponDataAccess().Update(data);
            //return result;

        }


    }
}
