using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.BrandDtos;

namespace Multishop.Catalog.Mappers.BrandMappers
{
    public class BrandProfile : Profile
    {
        public BrandProfile() 
        {
            CreateMap<Brand, BrandDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Brand, BrandDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Brand, BrandDto>().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
            CreateMap<Brand, BrandDto>().ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}