using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RoleRepo : IRoleRepo
{
    private readonly WiseTripsContext _context;

    public RoleRepo(WiseTripsContext context)
    {
        _context = context;
    }

    public async Task<List<Role>> GetAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Role> GetAsync(int id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task<bool> AddAsync(Role obj)
    {
        _context.Roles.Add(obj);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var role = await GetAsync(id);
        if (role != null)
        {
            _context.Roles.Remove(role);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<bool> UpdateAsync(Role obj)
    {
        var existingRole = await GetAsync(obj.Id);
        if (existingRole != null)
        {
            _context.Entry(existingRole).CurrentValues.SetValues(obj);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }
}
