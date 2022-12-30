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
            var agency = mapper.Map<Agency>(data);
            var ret = DataAccessFactory.AgencyDataAccess().Add(agency);
            
            if (ret != null)
            {
                return mapper.Map<AgencyDto>(data);
            }

            return null;
        }

        public static List<AgencyDto> Get()
        {
            var data = DataAccessFactory.AgencyDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Agency, AgencyDto>());
            var mapper = new Mapper(config);
            return mapper.Map<List<AgencyDto>>(data);
        }

        public static AgencyDto Get(int id)
        {
            var data = DataAccessFactory.AgencyDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Agency, AgencyDto>());
            var mapper = new Mapper(config);
            var user = mapper.Map<AgencyDto>(data);
            return user;
        }

        public static void Update(AgencyDto data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<AgencyDto, Agency>();
                c.CreateMap<Agency, AgencyDto>();
            });
            var mapper = new Mapper(config);
            var agency = mapper.Map<Agency>(data);
            DataAccessFactory.AgencyDataAccess().Update(agency);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.AgencyDataAccess().Delete(id);
        }
    }
}
