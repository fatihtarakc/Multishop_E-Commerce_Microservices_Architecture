using Microsoft.EntityFrameworkCore;
using Order.Application.Repositories.Abstract;
using Order.Domain.Entities.Abstract;
using Order.Persistance.Context;
using System.Linq.Expressions;

namespace Order.Persistance.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly OrderMicroserviceContext db;
        public GenericRepository(OrderMicroserviceContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                db.Entry<T>(entity).State = EntityState.Added;
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid entityId)
        {
            try
            {
                var entity = await db.Set<T>().FindAsync(entityId);
                if (entity is null) return false;

                db.Entry<T>(entity).State = EntityState.Deleted;
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                db.Entry<T>(entity).State = EntityState.Modified;
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await db.Set<T>().FirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await db.Set<T>().ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}