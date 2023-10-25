using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL.Services
{
    public class HotelService : IHotelService
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepo _hotelRepo;

        public HotelService(IMapper mapper, DataAccessFactory dataAccessFactory)
        {
            _mapper = mapper;
            _hotelRepo = dataAccessFactory.HotelDataAccess();
        }

        public async Task<List<HotelDto>> GetAsync()
        {
            var data = await _hotelRepo.GetAsync();
            return _mapper.Map<List<HotelDto>>(data);
        }

        public async Task<HotelDto> GetAsync(int id)
        {
            var data = await _hotelRepo.GetAsync(id);
            return _mapper.Map<HotelDto>(data);
        }

        public async Task<bool> AddAsync(HotelDto hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto);
            return await _hotelRepo.AddAsync(hotel);
        }

        public async Task UpdateAsync(HotelDto hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto);
            await _hotelRepo.UpdateAsync(hotel);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}