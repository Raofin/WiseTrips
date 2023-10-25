using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AuthService
    {
        private readonly IUserRepo _userRepo;
        private readonly IAuthRepo _auth;
        private readonly IToken _tokenRepo;

        public AuthService(DataAccessFactory dataAccessFactory)
        {
            _userRepo = dataAccessFactory.UserDataAccess();
            _auth = dataAccessFactory.AuthDataAccess();
            _tokenRepo = dataAccessFactory.TokenDataAccess();
        }

        public TokenDto Authenticate(string username, string password)
        { 
            var user = _auth.Authenticate(username, password);

            if (user != null)
            {
                var token = new Token {
                    AuthToken = Guid.NewGuid().ToString(),
                    CreatedOn = DateTime.Now,
                    ExpiredOn = DateTime.Now.AddHours(1),
                    UserId = _userRepo.Get().First(u => u.Username == username).Id
                };

                var rt = _tokenRepo.Add(token);

                if (rt == null) return null;

                var config = new MapperConfiguration(c => c.CreateMap<Token, TokenDto>());
                var mapper = new Mapper(config);

                return mapper.Map<TokenDto>(rt);
            }
            return null;
        }

        public bool TokenValidity(string value)
        {
            var token = _tokenRepo.Get(value);
            return Convert.ToDateTime(token.ExpiredOn) > DateTime.Now;
        }

        public bool Logout(string token)
        {
            return _auth.Logout(token);
        }
    }
}
