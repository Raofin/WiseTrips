using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class PackageRepo : IPackageRepo
{
    private readonly WiseTripsContext _context;

    public PackageRepo(WiseTripsContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Package obj)
    {
        _context.Packages.Add(obj);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var package = await GetAsync(id);
        if (package != null)
        {
            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<Package>> GetAsync()
    {
        return await _context.Packages.ToListAsync();
    }

    public async Task<Package> GetAsync(int id)
    {
        return await _context.Packages.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(Package obj)
    {
        var existingPackage = await GetAsync(obj.Id);

        if (existingPackage != null)
        {
            _context.Entry(existingPackage).CurrentValues.SetValues(obj);
            return await _context.SaveChangesAsync() > 0;
        }

        return false;
    }
}
