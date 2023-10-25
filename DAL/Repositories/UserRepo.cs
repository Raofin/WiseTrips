using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepo : IUserRepo, IAuthRepo
{
    private readonly WiseTripsContext _context;

    public UserRepo(WiseTripsContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(User obj)
    {
        _context.Users.Add(obj);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        _context.Users.Remove(user);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<User>> GetAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(User obj)
    {
        var ext = await GetAsync(obj.Id);
        _context.Entry(ext).CurrentValues.SetValues(obj);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<User> AuthenticateAsync(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.Username.Equals(username) &&
            u.Password.Equals(password)
        );
        return user;
    }

    public async Task<bool> LogoutAsync(string token)
    {
        var authToken = await _context.Tokens.FirstOrDefaultAsync(t => t.AuthToken.Equals(token));

        if (authToken == null)
            return false;

        authToken.ExpiredOn = DateTime.Now;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User> GetUserAsync(string token)
    {
        return await (from u in _context.Users
            where u.Id == (from t in _context.Tokens
                where t.AuthToken == token && t.ExpiredOn > DateTime.Now
                select t.UserId).FirstOrDefault()
            select u).FirstOrDefaultAsync();
    }
}