using BLL.DTOs;

namespace BLL.Services;

public interface IUserService : ICrudService<UserDto>
{
    Task<UserDto> GetAsync(string username);
    Task<UserDto> GetByTokenAsync(string token);
    Task<bool> RegisterAsync(UserDto userDto, string roleName);
}