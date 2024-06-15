using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.DetailDtos;

namespace Multishop.Catalog.Mappers.DetailMappers
{
    public class DetailProfile : Profile
    {
        public DetailProfile() 
        {
            CreateMap<Detail, DetailDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Detail, DetailDto>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Detail, DetailDto>().ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.Features));
        }
    }
}