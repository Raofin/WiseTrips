using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TripRepo : ITripRepo
{
    private readonly WiseTripsContext _context;

    public TripRepo(WiseTripsContext context)
    {
        _context = context;
    }

    public async Task<List<Trip>> GetAsync()
    {
        return await _context.Trips.ToListAsync();
    }

    public async Task<Trip> GetAsync(int id)
    {
        return await _context.Trips.FindAsync(id);
    }

    public async Task<bool> AddAsync(Trip obj)
    {
        _context.Trips.Add(obj);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var trip = await _context.Trips.FindAsync(id);
        if (trip != null)
        {
            _context.Trips.Remove(trip);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<bool> UpdateAsync(Trip obj)
    {
        var existingTrip = await GetAsync(obj.Id);
        if (existingTrip != null)
        {
            _context.Entry(existingTrip).CurrentValues.SetValues(obj);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }
}