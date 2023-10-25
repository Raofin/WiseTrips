using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Services
{
    public class CouponService
    {
       /* private readonly IMapper _mapper;
        private readonly ICouponRepo _couponRepo;

        public CouponService(IMapper mapper, DataAccessFactory dataAccessFactory)
        {
            _mapper = mapper;
            _couponRepo = dataAccessFactory.CouponDataAccess();
        }

        public List<CouponDto> Get()
        {
            var coupons = _couponRepo.Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponDto>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CouponDto>>(coupons);
            return data;
        }

        public CouponDto Get(int id)
        {
            var coupon = _couponRepo.Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Coupon, CouponDto>());
            var mapper = new Mapper(config);
            var data = mapper.Map<CouponDto>(coupon);
            return data;
        }

        public bool Add(CouponDto dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Coupon, CouponDto>();
                cfg.CreateMap<CouponDto, Coupon>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<Coupon>(dto);
            var result = _couponRepo.Add(data);
            return result;
        }

        public void Update(CouponDto coupon)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CouponDto, Coupon>();
                cfg.CreateMap<Coupon, CouponDto>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Coupon>(coupon);
            _couponRepo.Update(data);
        }*/
    }
}
