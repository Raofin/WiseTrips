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
    public class AuthService
    {
        public static TokenDto Authenticate(string username, string password)
        {
            var user = DataAccessFactory.AuthDataAccess().Authenticate(username, password);

            if (user != null)
            {
                var token = new Token {
                    AuthToken = Guid.NewGuid().ToString(),
                    CreatedOn = DateTime.Now,
                    ExpiredOn = DateTime.Now.AddHours(1),
                    UserId = DataAccessFactory.UserDataAccess().Get().First(u => u.Username == username).Id
                };

                var rt = DataAccessFactory.TokenDataAccess().Add(token);

                if (rt == null) return null;

                var config = new MapperConfiguration(c => c.CreateMap<Token, TokenDto>());
                var mapper = new Mapper(config);

                return mapper.Map<TokenDto>(rt);
            }
            return null;
        }

        public static bool TokenValidity(string value)
        {
            var token = DataAccessFactory.TokenDataAccess().Get(value);
            return Convert.ToDateTime(token.ExpiredOn) > DateTime.Now;
        }
    }
}
