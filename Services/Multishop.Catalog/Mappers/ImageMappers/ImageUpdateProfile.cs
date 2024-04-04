using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ImageDtos;

namespace Multishop.Catalog.Mappers.ImageMappers
{
    public class ImageUpdateProfile : Profile
    {
        public ImageUpdateProfile() 
        {
            CreateMap<Image, ImageUpdateDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Image, ImageUpdateDto>().ReverseMap().ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));
            CreateMap<Image, ImageUpdateDto>().ReverseMap().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}