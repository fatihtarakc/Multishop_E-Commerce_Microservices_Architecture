using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ContactDtos;

namespace Multishop.Catalog.Mappers.ContactMappers
{
    public class ContactProfile : Profile
    {
        public ContactProfile() 
        {
            CreateMap<Contact, ContactDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Contact, ContactDto>().ForMember(dest => dest.NameSurname, opt => opt.MapFrom(src => src.NameSurname));
            CreateMap<Contact, ContactDto>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<Contact, ContactDto>().ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));
            CreateMap<Contact, ContactDto>().ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
            CreateMap<Contact, ContactDto>().ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => src.IsRead));
            CreateMap<Contact, ContactDto>().ForMember(dest => dest.SendDate, opt => opt.MapFrom(src => src.SendDate));
            CreateMap<Contact, ContactDto>().ForMember(dest => dest.ReadDate, opt => opt.MapFrom(src => src.ReadDate));
        }
    }
}