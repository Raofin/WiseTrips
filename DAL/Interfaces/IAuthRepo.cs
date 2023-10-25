using DAL.Entity;

namespace DAL.Interfaces
{
    public interface IAuthRepo
    {
        User Authenticate(string username, string password);

        bool Logout(string token);

        User GetUser(string token);
    }
}