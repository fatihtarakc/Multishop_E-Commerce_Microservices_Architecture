using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ProductDtos;

namespace Multishop.Catalog.Mappers.ProductMappers
{
    public class ProductDetailProfile : Profile
    {
        public ProductDetailProfile() 
        {
            CreateMap<Product, ProductDetailDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Product, ProductDetailDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Product, ProductDetailDto>().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            CreateMap<Product, ProductDetailDto>().ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
            CreateMap<Product, ProductDetailDto>().ForMember(dest => dest.DetailId, opt => opt.MapFrom(src => src.DetailId));
            CreateMap<Product, ProductDetailDto>().ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));
        }
    }
}