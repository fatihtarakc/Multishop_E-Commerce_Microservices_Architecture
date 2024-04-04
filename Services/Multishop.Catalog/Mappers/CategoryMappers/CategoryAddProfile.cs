using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.CategoryDtos;

namespace Multishop.Catalog.Mappers.CategoryMappers
{
    public class CategoryAddProfile : Profile
    {
        public CategoryAddProfile()
        {
            CreateMap<CategoryAddDto, Category>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}