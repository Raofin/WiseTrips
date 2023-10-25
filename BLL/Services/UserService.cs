using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL.Services
{
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
                            
        public List<UserDto> Get()
        {
            var data = _userRepo.Get();
            return _mapper.Map<List<UserDto>>(data);
        }

        public UserDto Get(int id)
        {
            var data = _userRepo.Get(id);           
            return _mapper.Map<UserDto>(data);
        }

        public UserDto Get(string username)
        {
            var data = _userRepo.Get().FirstOrDefault(u => u.Username == username);
            return _mapper.Map<UserDto>(data);
        }

        public UserDto GetByToken(string token)
        {
            var data = _authRepo.GetUser(token);
            return _mapper.Map<UserDto>(data);
        }

        public UserDto Add(UserDto userDto)
        {
            /*var data = _mapper.Map<User>(userDto);

            if (Get(data.Username) != null)
                return false;

            return _userRepo.Add(data);*/

            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
             return _userRepo.Delete(id);
        }

        public void Update(UserDto user)
        {
            var data = _mapper.Map<User>(user);
            _userRepo.Update(data);
        }

        public bool Register(UserDto userDto, string roleName)
        {
            /*var role = new RoleDto
            {
                Name = roleName,
                AddedOn = DateTime.Now,
                UserId = 1
            };

            userDto.RegisteredOn = DateTime.Now;
            userDto.AccountStatus = true;

            return this.Add(userDto) && RoleService.Add(role);*/

            throw new NotImplementedException();
        }
    }
}
