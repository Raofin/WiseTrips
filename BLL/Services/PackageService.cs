using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PackageService
    {
        public static PackageDto Add(PackageDto data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<PackageDto, Package>();
                c.CreateMap<Package, PackageDto>();
            });
            var mapper = new Mapper(config);
            var package = mapper.Map<Package>(data);
            var ret = DataAccessFactory.PackageDataAccess().Add(package);

            if (ret != null)
            {
                return mapper.Map<PackageDto>(data);
            }
            return null;
        }

        public static List<PackageDto> Get()
        {
            var packages = DataAccessFactory.PackageDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Package, PackageDto>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<PackageDto>>(packages);
            return data;
        }

        public static PackageDto Get(int id)
        {
            var data = DataAccessFactory.PackageDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Package, PackageDto>());
            var mapper = new Mapper(config);
            var user = mapper.Map<PackageDto>(data);
            return user;
        }

        public static void Update(PackageDto data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<PackageDto, Package>();
                c.CreateMap<Package, PackageDto>();
            });
            var mapper = new Mapper(config);
            var package = mapper.Map<Package>(data);
            DataAccessFactory.PackageDataAccess().Update(package);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.PackageDataAccess().Delete(id);
        }
    }
}