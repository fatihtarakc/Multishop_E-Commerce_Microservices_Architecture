using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ImageDtos;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IImageService : IGenericService<Image, ImageDto, ImageAddDto, ImageUpdateDto>
    {
        Task<IEnumerable<ImageDto>> GetAllWhereAsync(Expression<Func<Image, bool>> expression);
    }
}