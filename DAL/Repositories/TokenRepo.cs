using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TokenRepo : IToken
{
    private readonly WiseTripsContext _context;

    public TokenRepo(WiseTripsContext context)
    {
        _context = context;
    }

    public async Task<Token> AddAsync(Token obj)
    {
        _context.Tokens.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var token = await GetAsync(id);
        if (token != null)
        {
            _context.Tokens.Remove(token);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<Token>> GetAsync()
    {
        return await _context.Tokens.ToListAsync();
    }

    public async Task<Token> GetAsync(string id)
    {
        return await _context.Tokens.FirstOrDefaultAsync(t => t.AuthToken.Equals(id));
    }

    public async Task<Token> UpdateAsync(Token obj)
    {
        var token = await GetAsync(obj.AuthToken);
        if (token != null)
        {
            _context.Entry(token).CurrentValues.SetValues(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        return null;
    }
}