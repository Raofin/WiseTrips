using AutoMapper;
using BLL.DTOs;
using DAL.Entity;
using DAL;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AgencyService
    {
        private readonly IMapper _mapper;
        private readonly IAgencyRepo _agencyRepo;

        public AgencyService(IMapper mapper, DataAccessFactory dataAccessFactory)
        {
            _mapper = mapper;
            _agencyRepo = dataAccessFactory.AgencyDataAccess();
        }

        public AgencyDto Add(AgencyDto data)
        {
            var agency = _mapper.Map<Agency>(data);
            var ret = _agencyRepo.Add(agency);

            return _mapper.Map<AgencyDto>(ret);
        }

        public List<AgencyDto> Get()
        {
            var data = _agencyRepo.Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Agency, AgencyDto>());
            var mapper = new Mapper(config);
            return mapper.Map<List<AgencyDto>>(data);
        }

        public AgencyDto Get(int id)
        {
            var data = _agencyRepo.Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Agency, AgencyDto>());
            var mapper = new Mapper(config);
            var user = mapper.Map<AgencyDto>(data);
            return user;
        }

        public void Update(AgencyDto data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<AgencyDto, Agency>();
                c.CreateMap<Agency, AgencyDto>();
            });
            var mapper = new Mapper(config);
            var agency = mapper.Map<Agency>(data);
            _agencyRepo.Update(agency);
        }

        public bool Delete(int id)
        {
            return _agencyRepo.Delete(id);
        }
    }
}
