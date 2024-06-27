using Multishop.Catalog.Data.Entities;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Abstract
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        Task<IEnumerable<Image>> GetAllWhereAsync(Expression<Func<Image, bool>> expression);
    }
}