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
            var dbobj = mapper.Map<Package>(data);
            var ret = DataAccessFactory.PackageDataAccess().Add(dbobj);
            if (ret != null)
            {
                return mapper.Map<PackageDto>(data);
            }
            else
            {
                return null;
            }



        }
        //public static object GetAll()
        // {
        //throw new NotImplementedException();
        //}
        public static List<PackageDto> Get()   //chnage3
        {

            var dbdata = DataAccessFactory.PackageDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Package, PackageDto>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<PackageDto>>(dbdata);  //List convert data by list

            return data;
        }

        public static PackageDto Get(int id)       //chnage2
        {
            var data = DataAccessFactory.PackageDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Package, PackageDto>());
            var mapper = new Mapper(config);
            var user = mapper.Map<PackageDto>(data);  //list convert user to list
            return user;



        }
        public static void Update(PackageDto data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<PackageDto, Package>();
                c.CreateMap<Package, PackageDto>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Package>(data);
            DataAccessFactory.PackageDataAccess().Update(dbobj);



        }
        public static bool Delete(int id)
        {
            var ret = DataAccessFactory.PackageDataAccess().Delete(id);
            return ret;




        }
    }
}