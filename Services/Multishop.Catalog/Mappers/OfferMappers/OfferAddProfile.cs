using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.OfferDtos;

namespace Multishop.Catalog.Mappers.OfferMappers
{
    public class OfferAddProfile : Profile
    {
        public OfferAddProfile() 
        {
            CreateMap<OfferAddDto, Offer>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<OfferAddDto, Offer>().ForMember(dest => dest.SubTitle, opt => opt.MapFrom(src => src.SubTitle));
            CreateMap<OfferAddDto, Offer>().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}