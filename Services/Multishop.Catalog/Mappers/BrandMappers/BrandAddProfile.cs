using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.BrandDtos;

namespace Multishop.Catalog.Mappers.BrandMappers
{
    public class BrandAddProfile : Profile
    {
        public BrandAddProfile() 
        {
            CreateMap<BrandAddDto, Brand>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<BrandAddDto, Brand>().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}