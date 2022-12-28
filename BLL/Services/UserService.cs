using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;

namespace BLL.Services
{
    public class UserService
    {
        private static Mapper mapper = new Mapper(
            new MapperConfiguration(cfg => {
               cfg.CreateMap<User, UserDto>();
               cfg.CreateMap<UserDto, User>();
            }));
                            
        public static List<UserDto> Get()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            return mapper.Map<List<UserDto>>(data);
        }

        public static UserDto Get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);           
            return mapper.Map<UserDto>(data);
        }

        public static UserDto Get(string username)
        {
            var data = DataAccessFactory.UserDataAccess().Get().FirstOrDefault(u => u.Username == username);
            return mapper.Map<UserDto>(data);
        }

        public static UserDto GetByToken(string token)
        {
            var data = DataAccessFactory.AuthDataAccess().GetUser(token);
            return mapper.Map<UserDto>(data);
        }

        public static bool Add(UserDto userDto)
        {
            var data = mapper.Map<User>(userDto);

            if (Get(data.Username) != null)
                return false;

            return DataAccessFactory.UserDataAccess().Add(data);
        }

        public static bool Delete(int id)
        {
             return DataAccessFactory.UserDataAccess().Delete(id);
        }

        public static bool Update(UserDto user)
        {
            var data = mapper.Map<User>(user);
            return DataAccessFactory.UserDataAccess().Update(data);
        }

        public static bool Register(UserDto userDto, string roleName)
        {
            var role = new RoleDto
            {
                Name = roleName,
                AddedOn = DateTime.Now,
                UserId = 1
            };

            userDto.RegisteredOn = DateTime.Now;
            userDto.AccountStatus = true;

            return UserService.Add(userDto) && RoleService.Add(role);
        }
    }
}
