using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.DetailDtos;

namespace Multishop.Catalog.Mappers.DetailMappers
{
    public class DetailListProfile : Profile
    {
        public DetailListProfile() 
        {
            CreateMap<Detail, DetailListDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Detail, DetailListDto>().ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info));
            CreateMap<Detail, DetailListDto>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Detail, DetailListDto>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}