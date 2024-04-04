using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.DetailDtos;

namespace Multishop.Catalog.Mappers.DetailMappers
{
    public class DetailDetailProfile : Profile
    {
        public DetailDetailProfile() 
        {
            CreateMap<Detail, DetailDetailDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Detail, DetailDetailDto>().ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info));
            CreateMap<Detail, DetailDetailDto>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Detail, DetailDetailDto>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}