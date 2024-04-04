using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.CategoryDtos;

namespace Multishop.Catalog.Mappers.CategoryMappers
{
    public class CategoryDetailProfile : Profile
    {
        public CategoryDetailProfile() 
        {
            CreateMap<Category, CategoryDetailDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Category, CategoryDetailDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Category, CategoryDetailDto>().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        }
    }
}