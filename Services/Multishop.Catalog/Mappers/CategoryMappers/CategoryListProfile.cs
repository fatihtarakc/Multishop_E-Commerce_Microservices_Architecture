using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.CategoryDtos;

namespace Multishop.Catalog.Mappers.CategoryMappers
{
    public class CategoryListProfile : Profile
    {
        public CategoryListProfile() 
        {
            CreateMap<Category, CategoryListDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Category, CategoryListDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}