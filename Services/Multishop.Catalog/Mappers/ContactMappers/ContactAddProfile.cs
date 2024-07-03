using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ContactDtos;

namespace Multishop.Catalog.Mappers.ContactMappers
{
    public class ContactAddProfile : Profile
    {
        public ContactAddProfile() 
        {
            CreateMap<ContactAddDto, Contact>().ForMember(dest => dest.NameSurname, opt => opt.MapFrom(src => src.NameSurname));
            CreateMap<ContactAddDto, Contact>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<ContactAddDto, Contact>().ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));
            CreateMap<ContactAddDto, Contact>().ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
        }
    }
}