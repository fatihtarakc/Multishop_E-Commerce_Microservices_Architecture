using Cargo.DataAccess.Context;
using Cargo.DataAccess.Repositories.Abstract;
using Cargo.Entity.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cargo.DataAccess.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CargoMicroserviceContext db;
        public GenericRepository(CargoMicroserviceContext db)
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

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
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