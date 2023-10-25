using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public interface IAuthService
    {
        Task<TokenDto> AuthenticateAsync(string username, string password);
        Task<bool> TokenValidityAsync(string value);
        Task<bool> LogoutAsync(string token);
    }
}