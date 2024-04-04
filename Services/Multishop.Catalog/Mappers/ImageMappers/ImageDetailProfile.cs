using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ImageDtos;

namespace Multishop.Catalog.Mappers.ImageMappers
{
    public class ImageDetailProfile : Profile
    {
        public ImageDetailProfile() 
        {
            CreateMap<Image, ImageDetailDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Image, ImageDetailDto>().ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));
            CreateMap<Image, ImageDetailDto>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}