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
       // private static Mapper mapper = new Mapper(
        //    new MapperConfiguration(cfg => {
        //       cfg.CreateMap<User, UserDto>();
         //      cfg.CreateMap<UserDto, User>();
        //    }));
                            
        public static List<UserDto> Get()              //chnage3      //user     //User
        {
            
            var dbdata = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<UserDto>>(dbdata);    //List convert data by list
            return data;
        }

        public static UserDto Get(int id)       //chnage2
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);           
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>());
            var mapper = new Mapper(config);
            var User = mapper.Map<UserDto>(data);  //list convert user to list
            return User;
        }



        public static UserDto Get(string username)       //chnage2
        {
            var data = DataAccessFactory.UserDataAccess().Get().FirstOrDefault(u => u.Username == username);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>());
            var mapper = new Mapper(config);
            var user = mapper.Map<UserDto>(data);  //list convert user to list
            return user;
        }

        // public static UserDto Get(string username)
        //{
        // var data = DataAccessFactory.UserDataAccess().Get().FirstOrDefault(u => u.Username == username);
        //   return data == null ? null : mapper.Map<UserDto>(data);
        //  }

        public static bool Add(UserDto userDto)            //chnage1    (donorservice)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserDto>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(userDto);     //list convert as user

            if (Get(data.Username) != null)
            {
                return false; 
            }

            return DataAccessFactory.UserDataAccess().Add(data);
        }

        public static void Delete(int ID)
        {
             DataAccessFactory.UserDataAccess().Delete(ID);
            //return result;
        }
        public static void Update(UserDto user)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserDto>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(user);
            DataAccessFactory.UserDataAccess().Update(data);
            //return result;

        }
        public static object GetAll()
        {
            throw new NotImplementedException();
        }

        //public static void Update(CouponDto coupon)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
