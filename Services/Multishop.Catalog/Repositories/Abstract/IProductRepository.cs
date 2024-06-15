using Multishop.Catalog.Data.Entities;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWhereAsync(Expression<Func<Product, bool>> expression);
    }
}