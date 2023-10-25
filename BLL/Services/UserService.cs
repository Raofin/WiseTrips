using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _userRepo;
    private readonly IAuthRepo _authRepo;

    public UserService(IMapper mapper, DataAccessFactory dataAccessFactory)
    {
        _mapper = mapper;
        _userRepo = dataAccessFactory.UserDataAccess();
        _authRepo = dataAccessFactory.AuthDataAccess();
    }

    public async Task<List<UserDto>> GetAsync()
    {
        var data = await _userRepo.GetAsync();
        return _mapper.Map<List<UserDto>>(data);
    }

    public async Task<UserDto> GetAsync(int id)
    {
        var data = await _userRepo.GetAsync(id);
        return _mapper.Map<UserDto>(data);
    }

    public async Task<UserDto> GetAsync(string username)
    {
        var data = (await _userRepo.GetAsync()).FirstOrDefault(u => u.Username == username);
        return _mapper.Map<UserDto>(data);
    }

    public async Task<UserDto> GetByTokenAsync(string token)
    {
        var data = await _authRepo.GetUserAsync(token);
        return _mapper.Map<UserDto>(data);
    }

    public async Task<bool> AddAsync(UserDto userDto)
    {
        var data = _mapper.Map<User>(userDto);

        // Check if user already exists
        var existingUser = await GetAsync(data.Username);
        if (existingUser != null)
            return false;

        // Add the new user
        return await _userRepo.AddAsync(data);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepo.DeleteAsync(id);
    }

    public async Task UpdateAsync(UserDto user)
    {
        var data = _mapper.Map<User>(user);
        await _userRepo.UpdateAsync(data);
    }

    public async Task<bool> RegisterAsync(UserDto userDto, string roleName)
    {
        // Add user
        var addedUser = await AddAsync(userDto);

        if (addedUser == null)
            return false;

        // Add role - you'll need to implement the role logic
        /*var role = new RoleDto {
            Name = roleName,
            AddedOn = DateTime.Now,
            UserId = addedUser.Id
        };*/

        // Implement RoleService logic for adding roles

        return true;
    }
}