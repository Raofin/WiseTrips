using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class AgencyRepo : IAgencyRepo
{
    private readonly WiseTripsContext _context;

    public AgencyRepo(WiseTripsContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Agency obj)
    {
        _context.Agencies.Add(obj);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var agency = await GetAsync(id);
        if (agency != null)
        {
            _context.Agencies.Remove(agency);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<List<Agency>> GetAsync()
    {
        return await _context.Agencies.ToListAsync();
    }

    public async Task<Agency> GetAsync(int id)
    {
        return await _context.Agencies.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(Agency obj)
    {
        var existingAgency = await GetAsync(obj.Id);
        _context.Entry(existingAgency).CurrentValues.SetValues(obj);
        return await _context.SaveChangesAsync() > 0;
    }
}