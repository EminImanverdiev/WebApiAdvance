using AutoMapper;
using WebApiAdvance.Entities;
using WebApiAdvance.Entities.DTOs.Products;

namespace WebApiAdvance.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<GetProdcutDto, Product>().ReverseMap().ForMember(opt=>opt.BrandName,opt=>opt.MapFrom(p=>p.Brand.Name));




        }
    }
}
