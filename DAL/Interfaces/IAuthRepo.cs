using DAL.Entity;

namespace DAL.Interfaces;

public interface IAuthRepo
{
    Task<User> AuthenticateAsync(string username, string password);

    Task<bool> LogoutAsync(string token);

    Task<User> GetUserAsync(string token);
}