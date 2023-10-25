using AutoMapper;
using BLL.DTOs;
using DAL.Entity;
using DAL;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AgencyService : IAgencyService
    {
        private readonly IMapper _mapper;
        private readonly IAgencyRepo _agencyRepo;

        public AgencyService(IMapper mapper, DataAccessFactory dataAccessFactory)
        {
            _mapper = mapper;
            _agencyRepo = dataAccessFactory.AgencyDataAccess();
        }

        public async Task<bool> AddAsync(AgencyDto data)
        {
            var agency = _mapper.Map<Agency>(data);
            return await _agencyRepo.AddAsync(agency);
        }

        public async Task<List<AgencyDto>> GetAsync()
        {
            var data = await _agencyRepo.GetAsync();
            return _mapper.Map<List<AgencyDto>>(data);
        }

        public async Task<AgencyDto> GetAsync(int id)
        {
            var data = await _agencyRepo.GetAsync(id);
            return _mapper.Map<AgencyDto>(data);
        }

        public async Task UpdateAsync(AgencyDto data)
        {
            var agency = _mapper.Map<Agency>(data);
            await _agencyRepo.UpdateAsync(agency);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _agencyRepo.DeleteAsync(id);
        }
    }
}