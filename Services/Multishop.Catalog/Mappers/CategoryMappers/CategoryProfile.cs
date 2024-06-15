using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.CategoryDtos;

namespace Multishop.Catalog.Mappers.CategoryMappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Category, CategoryDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}