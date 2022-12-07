using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            new MapperConfiguration(c => {
                c.CreateMap<User, UserDto>();
                c.CreateMap<UserDto, User>();
            }));

        public static List<UserDto> GetAll()
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
            return data == null ? null : mapper.Map<UserDto>(data);
        }

        public static bool Add(UserDto userDto)
        {
            var user = mapper.Map<User>(userDto);
            return DataAccessFactory.UserDataAccess().Add(user);
        }
    }
}
