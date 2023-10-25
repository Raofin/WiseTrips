using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL.Services;

public class TripService : ITripService
{
    private readonly IMapper _mapper;
    private readonly ITripRepo _tripRepo;

    public TripService(IMapper mapper, DataAccessFactory dataAccessFactory)
    {
        _mapper = mapper;
        _tripRepo = dataAccessFactory.TripDataAccess();
    }

    public async Task<List<TripDto>> GetAllAsync()
    {
        var data = await _tripRepo.GetAsync();
        return _mapper.Map<List<TripDto>>(data);
    }

    public Task<List<TripDto>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TripDto> GetAsync(int id)
    {
        var data = await _tripRepo.GetAsync(id);
        return _mapper.Map<TripDto>(data);
    }

    public Task UpdateAsync(TripDto data)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddAsync(TripDto tripDto)
    {
        /*var trip = mapper.Map<Trip>(tripDto);

        var discount = trip.UsedCoupon != null
            ? CouponService.Get((int)trip.UsedCoupon).Discount
            : 0;

        // amount = package price + (hotel price * persons)
        var amount = PackageService.Get(trip.PackageId).Price + HotelService.Get(trip.HotelId).Price * trip.Persons + discount;

        // discount calculation
        trip.Paid = amount - (amount * discount / 100);

        trip.Date = DateTime.Now;
        return DataAccessFactory.TripDataAccess().Add(trip);*/

        throw new NotImplementedException();
    }
}