using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ProductDtos;

namespace Multishop.Catalog.Mappers.ProductMappers
{
    public class ProductAddProfile : Profile
    {
        public ProductAddProfile() 
        {
            CreateMap<ProductAddDto, Product>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<ProductAddDto, Product>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<ProductAddDto, Product>().ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            CreateMap<ProductAddDto, Product>().ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
        }
    }
}