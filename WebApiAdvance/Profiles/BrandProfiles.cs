using AutoMapper;
using WebApiAdvance.Entities;
using WebApiAdvance.Entities.DTOs.Brands;

namespace WebApiAdvance.Profiles
{
    public class BrandProfiles:Profile
    {
        public BrandProfiles()
        {
            CreateMap<Brand, GetBrandDto>();
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<Brand, CreateBrandDto>();
        }
    }
}
