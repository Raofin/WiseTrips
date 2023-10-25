using BLL.DTOs;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface IUserService : ICrudService<UserDto>
    {
        UserDto Get(string username);
        UserDto GetByToken(string token);
        bool Register(UserDto userDto, string roleName);
    }
}
