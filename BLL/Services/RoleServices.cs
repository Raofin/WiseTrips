using AutoMapper;
using BLL.DTOs;
using DAL.Entity;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepo _roleRepo;

        public RoleService(IMapper mapper, DataAccessFactory dataAccessFactory)
        {
            _mapper = mapper;
            _roleRepo = dataAccessFactory.RoleDataAccess();
        }

        public async Task<List<RoleDto>> GetAsync()
        {
            var data = await _roleRepo.GetAsync();
            return _mapper.Map<List<RoleDto>>(data);
        }

        public async Task<RoleDto> GetAsync(int id)
        {
            var data = await _roleRepo.GetAsync(id);
            return _mapper.Map<RoleDto>(data);
        }

        public async Task<bool> AddAsync(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            return await _roleRepo.AddAsync(role);
        }

        public async Task UpdateAsync(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            await _roleRepo.UpdateAsync(role);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _roleRepo.DeleteAsync(id);
        }
    }
}