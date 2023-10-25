using System.Collections.Generic;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entity;
using DAL.Interfaces;

namespace BLL.Services
{
    public class RoleService
    {
       /* private readonly IMapper _mapper;
        private readonly IRoleRepo _roleRepo;

        public RoleService(IMapper mapper, DataAccessFactory dataAccessFactory)
        {
            _mapper = mapper;
            _roleRepo = dataAccessFactory.RoleDataAccess();
        }

        private static readonly Mapper mapper = new Mapper(
            new MapperConfiguration(c => {
                c.CreateMap<Role, RoleDto>();
                c.CreateMap<RoleDto, Role>();
            })
        );

        public List<RoleDto> GetAll()
        {
            var data = _roleRepo.Get();
            return mapper.Map<List<RoleDto>>(data);
        }

        public RoleDto Get(int id)
        {
            var data = _roleRepo.Get(id);
            return mapper.Map<RoleDto>(data);
        }

        public bool Add(RoleDto roleDto)
        {
            var role = mapper.Map<Role>(roleDto);
            return _roleRepo.Add(role);
        }

        public bool Update(RoleDto roleDto)
        {
            var role = mapper.Map<Role>(roleDto);
            return _roleRepo.Update(role);
        }*/
    }
}