using System.Collections.Generic;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;

namespace BLL.Services
{
    public class HotelService
    {
        private static readonly Mapper mapper = new Mapper(
            new MapperConfiguration(c => {
                c.CreateMap<Hotel, HotelDto>();
                c.CreateMap<HotelDto, Hotel>();
            })
        );

        public static List<HotelDto> GetAll()
        {
            var data = DataAccessFactory.HotelDataAccess().Get();
            return mapper.Map<List<HotelDto>>(data);
        }

        public static HotelDto Get(int id)
        {
            var data = DataAccessFactory.HotelDataAccess().Get(id);
            return mapper.Map<HotelDto>(data);
        }

        public static bool Add(HotelDto hotelDto)
        {
            var hotel = mapper.Map<Hotel>(hotelDto);
            return DataAccessFactory.HotelDataAccess().Add(hotel);
        }

        public static bool Update(HotelDto hotelDto)
        {
            var hotel = mapper.Map<Hotel>(hotelDto);
            return DataAccessFactory.HotelDataAccess().Update(hotel);
        }
    }
}