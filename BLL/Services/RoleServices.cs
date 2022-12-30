using System.Collections.Generic;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;

namespace BLL.Services
{
    public class RoleService
    {
        private static readonly Mapper mapper = new Mapper(
            new MapperConfiguration(c => {
                c.CreateMap<Role, RoleDto>();
                c.CreateMap<RoleDto, Role>();
            })
        );

        public static List<RoleDto> GetAll()
        {
            var data = DataAccessFactory.RoleDataAccess().Get();
            return mapper.Map<List<RoleDto>>(data);
        }

        public static RoleDto Get(int id)
        {
            var data = DataAccessFactory.RoleDataAccess().Get(id);
            return mapper.Map<RoleDto>(data);
        }

        public static bool Add(RoleDto roleDto)
        {
            var role = mapper.Map<Role>(roleDto);
            return DataAccessFactory.RoleDataAccess().Add(role);
        }

        public static bool Update(RoleDto roleDto)
        {
            var role = mapper.Map<Role>(roleDto);
            return DataAccessFactory.RoleDataAccess().Update(role);
        }
    }
}