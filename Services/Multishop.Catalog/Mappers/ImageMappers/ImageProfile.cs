using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ImageDtos;

namespace Multishop.Catalog.Mappers.ImageMappers
{
    public class ImageProfile : Profile
    {
        public ImageProfile() 
        {
            CreateMap<Image, ImageDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Image, ImageDto>().ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));
        }
    }
}