using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ProductDtos;

namespace Multishop.Catalog.Mappers.ProductMappers
{
    public class ProductUpdateProfile : Profile
    {
        public ProductUpdateProfile() 
        {
            CreateMap<Product, ProductUpdateDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Product, ProductUpdateDto>().ReverseMap().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Product, ProductUpdateDto>().ReverseMap().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            CreateMap<Product, ProductUpdateDto>().ReverseMap().ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
        }
    }
}