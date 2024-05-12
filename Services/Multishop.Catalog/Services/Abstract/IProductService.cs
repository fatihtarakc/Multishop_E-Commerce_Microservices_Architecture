using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Dtos.ProductDtos;

namespace Multishop.Catalog.Services.Abstract
{
    public interface IProductService : IGenericService<Product, ProductAddDto, ProductUpdateDto, ProductDetailDto, ProductListDto>
    {
    }
}