using AutoMapper;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ImageDtos;

namespace Multishop.Catalog.Mappers.ImageMappers
{
    public class ImageAddProfile : Profile
    {
        public ImageAddProfile() 
        {
            CreateMap<ImageAddDto, Image>().ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));
            CreateMap<ImageAddDto, Image>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}