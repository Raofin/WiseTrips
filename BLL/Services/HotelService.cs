using System.Collections.Generic;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL.Services
{
    public class HotelService
    {
       /* private readonly IMapper _mapper;
        private readonly IHotelRepo _hotelRepo;

        public HotelService(IMapper mapper, DataAccessFactory dataAccessFactory)
        {
            _mapper = mapper;
            _hotelRepo = dataAccessFactory.HotelDataAccess();
        }

        private static readonly Mapper mapper = new Mapper(
            new MapperConfiguration(c => {
                c.CreateMap<Hotel, HotelDto>();
                c.CreateMap<HotelDto, Hotel>();
            })
        );

        public List<HotelDto> GetAll()
        {
            var data = _hotelRepo.Get();
            return mapper.Map<List<HotelDto>>(data);
        }

        public HotelDto Get(int id)
        {
            var data = _hotelRepo.Get(id);
            return mapper.Map<HotelDto>(data);
        }

        public bool Add(HotelDto hotelDto)
        {
            var hotel = mapper.Map<Hotel>(hotelDto);
            return _hotelRepo.Add(hotel);
        }

        public bool Update(HotelDto hotelDto)
        {
            var hotel = mapper.Map<Hotel>(hotelDto);
            return _hotelRepo.Update(hotel);
        }*/
    }
}