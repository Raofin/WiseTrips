using AutoMapper;
using BLL.DTOs;
using DAL.Entity;

namespace BLL
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AgencyDto, Agency>();
            CreateMap<Agency, AgencyDto>();

            CreateMap<Coupon, CouponDto>();
            CreateMap<CouponDto, Coupon>();

            CreateMap<Hotel, HotelDto>();
            CreateMap<HotelDto, Hotel>();

            CreateMap<PackageDto, Package>();
            CreateMap<Package, PackageDto>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<Trip, TripDto>();
            CreateMap<TripDto, Trip>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
