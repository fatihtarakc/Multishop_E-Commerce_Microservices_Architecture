using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.DetailDtos;

namespace Multishop.Catalog.Mappers.DetailMappers
{
    public class DetailAddProfile : Profile
    {
        public DetailAddProfile() 
        {
            CreateMap<DetailAddDto, Detail>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<DetailAddDto, Detail>().ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Info));
            CreateMap<DetailAddDto, Detail>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}