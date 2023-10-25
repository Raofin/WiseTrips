using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL.Services;

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

    public async Task<TokenDto> AuthenticateAsync(string username, string password)
    {
        var user = await _auth.AuthenticateAsync(username, password);

        if (user != null)
        {
            var userEntity = (await _userRepo.GetAsync()).FirstOrDefault(u => u.Username == username);

            if (userEntity != null)
            {
                var token = new Token {
                    AuthToken = Guid.NewGuid().ToString(),
                    CreatedOn = DateTime.Now,
                    ExpiredOn = DateTime.Now.AddHours(1),
                    UserId = userEntity.Id
                };

                var rt = await _tokenRepo.AddAsync(token);

                if (rt != null)
                {
                    var config = new MapperConfiguration(c => c.CreateMap<Token, TokenDto>());
                    var mapper = new Mapper(config);

                    return mapper.Map<TokenDto>(rt);
                }
            }
        }

        return null;
    }

    public async Task<bool> TokenValidityAsync(string value)
    {
        var token = await _tokenRepo.GetAsync(value);
        return Convert.ToDateTime(token.ExpiredOn) > DateTime.Now;
    }

    public async Task<bool> LogoutAsync(string token)
    {
        return await _auth.LogoutAsync(token);
    }
}