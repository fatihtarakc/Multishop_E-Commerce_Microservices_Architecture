using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.CategoryDtos;

namespace Multishop.Catalog.Services.Abstract
{
    public interface ICategoryService : IGenericService<Category, CategoryAddDto, CategoryUpdateDto, CategoryDetailDto, CategoryListDto>
    {
    }
}