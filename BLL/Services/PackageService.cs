using AutoMapper;
using BLL.DTOs;
using DAL.Entity;
using DAL;
using DAL.Interfaces;

namespace BLL.Services;

public class PackageService : IPackageService
{
    private readonly IMapper _mapper;
    private readonly IPackageRepo _packageRepo;

    public PackageService(IMapper mapper, DataAccessFactory dataAccessFactory)
    {
        _mapper = mapper;
        _packageRepo = dataAccessFactory.PackageDataAccess();
    }

    public async Task<bool> AddAsync(PackageDto data)
    {
        var package = _mapper.Map<Package>(data);
        return await _packageRepo.AddAsync(package);
    }

    public async Task<List<PackageDto>> GetAsync()
    {
        var packages = await _packageRepo.GetAsync();
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Package, PackageDto>());
        var mapper = new Mapper(config);
        var data = mapper.Map<List<PackageDto>>(packages);
        return data;
    }

    public async Task<PackageDto> GetAsync(int id)
    {
        var data = await _packageRepo.GetAsync(id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Package, PackageDto>());
        var mapper = new Mapper(config);
        var user = mapper.Map<PackageDto>(data);
        return user;
    }

    public async Task UpdateAsync(PackageDto data)
    {
        var config = new MapperConfiguration(c => {
            c.CreateMap<PackageDto, Package>();
            c.CreateMap<Package, PackageDto>();
        });
        var mapper = new Mapper(config);
        var package = mapper.Map<Package>(data);
        await _packageRepo.UpdateAsync(package);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _packageRepo.DeleteAsync(id);
    }
}