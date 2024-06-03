using Order.Domain.Entities.Abstract;
using System.Linq.Expressions;

namespace Order.Application.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(Guid entityId);
        Task<bool> UpdateAsync(T entity);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
    }
}