using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;

namespace BLL.Services
{
    public class TripService
    {
        private static Mapper mapper = new Mapper(
            new MapperConfiguration(c => {
                c.CreateMap<Trip, TripDto>();
                c.CreateMap<TripDto, Trip>();
            }));

        public static List<TripDto> GetAll()
        {
            var data = DataAccessFactory.TripDataAccess().Get();
            return mapper.Map<List<TripDto>>(data);
        }

        public static TripDto Get(int id)
        {
            var data = DataAccessFactory.TripDataAccess().Get(id);
            return mapper.Map<TripDto>(data);
        }

        public static bool Add(TripDto tripDto)
        {
            var trip = mapper.Map<Trip>(tripDto);
            var discount = trip.UsedCoupon != null ? CouponService.Get((int)trip.UsedCoupon).Discount : 0;

            // amount = package price + (hotel price * persons)
            var amount = PackageService.Get(trip.PackageId).Price + HotelService.Get(trip.HotelId).Price * trip.Persons + discount;
            
            // discount calculation
            trip.Paid = amount - (amount * discount / 100);
            
            trip.Date = DateTime.Now;
            return DataAccessFactory.TripDataAccess().Add(trip);
        }
    }
}
