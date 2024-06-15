using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ProductDtos;

namespace Multishop.Catalog.Mappers.ProductMappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Product, ProductDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Product, ProductDto>().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}