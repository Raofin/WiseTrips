using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class HotelRepo : IHotelRepo
{
    private readonly WiseTripsContext _context;

    public HotelRepo(WiseTripsContext context)
    {
        _context = context;
    }

    public async Task<List<Hotel>> GetAsync()
    {
        return await _context.Hotels.ToListAsync();
    }

    public async Task<Hotel> GetAsync(int id)
    {
        return await _context.Hotels.FindAsync(id);
    }

    public async Task<bool> AddAsync(Hotel obj)
    {
        _context.Hotels.Add(obj);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var hotel = await GetAsync(id);
        if (hotel != null)
        {
            _context.Hotels.Remove(hotel);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<bool> UpdateAsync(Hotel obj)
    {
        var existingHotel = await GetAsync(obj.Id);
        if (existingHotel != null)
        {
            _context.Entry(existingHotel).CurrentValues.SetValues(obj);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }
}