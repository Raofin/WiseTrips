using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BLL.Services
{
    public class AgencyService
    {
        public static AgencyDto Add(AgencyDto data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<AgencyDto, Agency>();
                c.CreateMap<Agency, AgencyDto>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Agency>(data);
            var ret = DataAccessFactory.AgencyDataAccess().Add(dbobj);
            if (ret != null)
            {
                return mapper.Map<AgencyDto>(data);
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
        public static List<AgencyDto> Get()   //chnage3
        {

            var dbdata = DataAccessFactory.AgencyDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Agency, AgencyDto>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<AgencyDto>>(dbdata);  //List convert data by list

            return data;
        }

        public static AgencyDto Get(int id)       //chnage2
        {
            var data = DataAccessFactory.AgencyDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Agency, AgencyDto>());
            var mapper = new Mapper(config);
            var user = mapper.Map<AgencyDto>(data);  //list convert user to list
            return user;



        }
        public static void Update(AgencyDto data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<AgencyDto, Agency>();
                c.CreateMap<Agency, AgencyDto>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Agency>(data);
            DataAccessFactory.AgencyDataAccess().Update(dbobj);
           


        }
        public static bool Delete(int id)
        {
            var ret = DataAccessFactory.AgencyDataAccess().Delete(id);
            return ret;




        }
    }

}
