using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.CategoryDtos;

namespace Multishop.Catalog.Services.Abstract
{
    public interface ICategoryService : IGenericService<Category, CategoryDto, CategoryAddDto, CategoryUpdateDto>
    {
    }
}