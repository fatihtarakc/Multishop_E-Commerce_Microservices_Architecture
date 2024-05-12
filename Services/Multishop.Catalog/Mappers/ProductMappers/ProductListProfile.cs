using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ProductDtos;

namespace Multishop.Catalog.Mappers.ProductMappers
{
    public class ProductListProfile : Profile
    {
        public ProductListProfile() 
        {
            CreateMap<Product, ProductListDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Product, ProductListDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Product, ProductListDto>().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            CreateMap<Product, ProductListDto>().ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
        }
    }
}