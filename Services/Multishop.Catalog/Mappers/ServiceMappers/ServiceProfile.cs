using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ServiceDtos;

namespace Multishop.Catalog.Mappers.ServiceMappers
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile() 
        {
            CreateMap<Service, ServiceDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Service, ServiceDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Service, ServiceDto>().ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon));
            CreateMap<Service, ServiceDto>().ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}