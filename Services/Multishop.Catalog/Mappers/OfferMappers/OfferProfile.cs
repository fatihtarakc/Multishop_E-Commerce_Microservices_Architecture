using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.OfferDtos;

namespace Multishop.Catalog.Mappers.OfferMappers
{
    public class OfferProfile : Profile
    {
        public OfferProfile() 
        {
            CreateMap<Offer, OfferDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Offer, OfferDto>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Offer, OfferDto>().ForMember(dest => dest.SubTitle, opt => opt.MapFrom(src => src.SubTitle));
            CreateMap<Offer, OfferDto>().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
            CreateMap<Offer, OfferDto>().ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}