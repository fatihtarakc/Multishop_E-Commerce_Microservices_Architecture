using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.OfferDtos;

namespace Multishop.Catalog.Mappers.OfferMappers
{
    public class OfferUpdateProfile : Profile
    {
        public OfferUpdateProfile() 
        {
            CreateMap<Offer, OfferUpdateDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Offer, OfferUpdateDto>().ReverseMap().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Offer, OfferUpdateDto>().ReverseMap().ForMember(dest => dest.SubTitle, opt => opt.MapFrom(src => src.SubTitle));
            CreateMap<Offer, OfferUpdateDto>().ReverseMap().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
            CreateMap<Offer, OfferUpdateDto>().ReverseMap().ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}