using AutoMapper;
using WebApiAdvance.Entities;
using WebApiAdvance.Entities.DTOs.Brands;

namespace WebApiAdvance.Profiles
{
    public class BrandProfiles : Profile
    {
        public BrandProfiles()
        {
            CreateMap<Brand, GetBrandDto>();
            CreateMap<CreateBrandDto, Brand>()
                 .ForMember(dest => dest.CreatedAt, 
                 opt=> opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<Brand, CreateBrandDto>();
        }
    }
}
