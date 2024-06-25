using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ServiceDtos;

namespace Multishop.Catalog.Mappers.ServiceMappers
{
    public class ServiceAddProfile : Profile
    {
        public ServiceAddProfile() 
        {
            CreateMap<ServiceAddDto, Service>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<ServiceAddDto, Service>().ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon));
        }
    }
}