using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ContactDtos;

namespace Multishop.Catalog.Mappers.ContactMappers
{
    public class ContactUpdateProfile : Profile
    {
        public ContactUpdateProfile() 
        {
            CreateMap<ContactUpdateDto, Contact>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<ContactUpdateDto, Contact>().ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => src.IsRead));
            CreateMap<ContactUpdateDto, Contact>().ForMember(dest => dest.ReadDate, opt => opt.MapFrom(src => src.ReadDate));
        }
    }
}