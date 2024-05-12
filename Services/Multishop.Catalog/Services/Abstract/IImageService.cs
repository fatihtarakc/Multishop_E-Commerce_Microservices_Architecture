using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ImageDtos;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IImageService : IGenericService<Image, ImageAddDto, ImageUpdateDto, ImageDetailDto, ImageListDto>
    {
    }
}