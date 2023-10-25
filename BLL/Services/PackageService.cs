using AutoMapper;
using BLL.DTOs;
using DAL.Entity;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Services
{
    public class PackageService
    {
       /* private readonly IMapper _mapper;
        private readonly IPackageRepo _packageRepo;

        public PackageService(IMapper mapper, DataAccessFactory dataAccessFactory)
        {
            _mapper = mapper;
            _packageRepo = dataAccessFactory.PackageDataAccess();
        }

        public PackageDto Add(PackageDto data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<PackageDto, Package>();
                c.CreateMap<Package, PackageDto>();
            });
            var mapper = new Mapper(config);
            var package = mapper.Map<Package>(data);
            var ret = _packageRepo.Add(package);

            if (ret != null)
            {
                return mapper.Map<PackageDto>(data);
            }
            return null;
        }

        public List<PackageDto> Get()
        {
            var packages = _packageRepo.Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Package, PackageDto>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<PackageDto>>(packages);
            return data;
        }

        public PackageDto Get(int id)
        {
            var data = _packageRepo.Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Package, PackageDto>());
            var mapper = new Mapper(config);
            var user = mapper.Map<PackageDto>(data);
            return user;
        }

        public void Update(PackageDto data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<PackageDto, Package>();
                c.CreateMap<Package, PackageDto>();
            });
            var mapper = new Mapper(config);
            var package = mapper.Map<Package>(data);
            _packageRepo.Update(package);
        }

        public bool Delete(int id)
        {
            return _packageRepo.Delete(id);
        }*/
    }
}