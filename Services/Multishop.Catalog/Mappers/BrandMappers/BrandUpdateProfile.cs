using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.BrandDtos;

namespace Multishop.Catalog.Mappers.BrandMappers
{
    public class BrandUpdateProfile : Profile
    {
        public BrandUpdateProfile() 
        {
            CreateMap<Brand, BrandUpdateDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Brand, BrandUpdateDto>().ReverseMap().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Brand, BrandUpdateDto>().ReverseMap().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
            CreateMap<Brand, BrandUpdateDto>().ReverseMap().ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}