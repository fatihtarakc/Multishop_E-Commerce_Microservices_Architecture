using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ImageDtos;

namespace Multishop.Catalog.Mappers.ImageMappers
{
    public class ImageListProfile : Profile
    {
        public ImageListProfile() 
        {
            CreateMap<Image, ImageListDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Image, ImageListDto>().ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));
            CreateMap<Image, ImageListDto>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}