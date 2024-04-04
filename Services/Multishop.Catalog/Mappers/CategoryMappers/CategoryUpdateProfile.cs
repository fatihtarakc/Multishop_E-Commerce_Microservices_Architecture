using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.CategoryDtos;

namespace Multishop.Catalog.Mappers.CategoryMappers
{
    public class CategoryUpdateProfile : Profile
    {
        public CategoryUpdateProfile() 
        {
            CreateMap<Category, CategoryUpdateDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Category, CategoryUpdateDto>().ReverseMap().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}