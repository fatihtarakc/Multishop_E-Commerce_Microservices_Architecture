using Cargo.Entity.Entities.Abstract;
using System.Linq.Expressions;

namespace Cargo.DataAccess.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
    }
}