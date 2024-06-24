using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.AdvertisementDtos;

namespace Multishop.Catalog.Mappers.AdvertisementMappers
{
    public class AdvertisementAddProfile : Profile
    {
        public AdvertisementAddProfile() 
        {
            CreateMap<AdvertisementAddDto, Advertisement>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<AdvertisementAddDto, Advertisement>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<AdvertisementAddDto, Advertisement>().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}