using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TripService
    {
       /* private readonly IMapper _mapper;
        private readonly ITripRepo _tripRepo;

        public TripService(IMapper mapper, DataAccessFactory dataAccessFactory)
        {
            _mapper = mapper;
            _tripRepo = dataAccessFactory.TripDataAccess();
        }

        private static Mapper mapper = new Mapper(
            new MapperConfiguration(c => {
                c.CreateMap<Trip, TripDto>();
                c.CreateMap<TripDto, Trip>();
            })
        );

        public List<TripDto> GetAll()
        {
            var data = _tripRepo.Get();
            return mapper.Map<List<TripDto>>(data);
        }

        public TripDto Get(int id)
        {
            var data = _tripRepo.Get(id);
            return mapper.Map<TripDto>(data);
        }

        public bool Add(TripDto tripDto)
        {
            *//*var trip = mapper.Map<Trip>(tripDto);

            var discount = trip.UsedCoupon != null 
                ? CouponService.Get((int)trip.UsedCoupon).Discount 
                : 0;

            // amount = package price + (hotel price * persons)
            var amount = PackageService.Get(trip.PackageId).Price + HotelService.Get(trip.HotelId).Price * trip.Persons + discount;
            
            // discount calculation
            trip.Paid = amount - (amount * discount / 100);
            
            trip.Date = DateTime.Now;
            return DataAccessFactory.TripDataAccess().Add(trip);*//*
            throw new NotImplementedException();
        }*/
    }
}
