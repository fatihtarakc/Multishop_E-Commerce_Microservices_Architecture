using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.AdvertisementDtos;

namespace Multishop.Catalog.Mappers.AdvertisementMappers
{
    public class AdvertisementUpdateProfile : Profile
    {
        public AdvertisementUpdateProfile() 
        {
            CreateMap<Advertisement, AdvertisementUpdateDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Advertisement, AdvertisementUpdateDto>().ReverseMap().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Advertisement, AdvertisementUpdateDto>().ReverseMap().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<Advertisement, AdvertisementUpdateDto>().ReverseMap().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
            CreateMap<Advertisement, AdvertisementUpdateDto>().ReverseMap().ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}