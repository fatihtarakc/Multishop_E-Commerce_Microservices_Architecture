using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ProductDtos;
using System.Linq.Expressions;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IProductService : IGenericService<Product, ProductDto, ProductAddDto, ProductUpdateDto>
    {
        Task<IEnumerable<ProductDto>> GetAllWhereAsync(Expression<Func<Product, bool>> expression);
    }
}