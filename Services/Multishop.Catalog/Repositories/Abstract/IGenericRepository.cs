using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Abstract
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task AddAsync(Entity entity);
        Task DeleteAsync(string entityId);
        Task UpdateAsync(Entity entity);
        Task<Entity> GetFirstOrDefaultAsync(Expression<Func<Entity, bool>> expression);
        //Task<IEnumerable<Entity>> GetAllWhereAsync(Expression<Func<Entity, bool>> expression);
        Task<IEnumerable<Entity>> GetAllAsync();
    }
}