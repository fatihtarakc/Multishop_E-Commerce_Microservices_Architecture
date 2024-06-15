using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.DetailDtos;

namespace Multishop.Catalog.Mappers.DetailMappers
{
    public class DetailUpdateProfile : Profile
    {
        public DetailUpdateProfile() 
        {
            CreateMap<Detail, DetailUpdateDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Detail, DetailUpdateDto>().ReverseMap().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Detail, DetailUpdateDto>().ReverseMap().ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.Features));
            CreateMap<Detail, DetailUpdateDto>().ReverseMap().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}