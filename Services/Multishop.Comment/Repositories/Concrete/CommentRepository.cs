using Microsoft.EntityFrameworkCore;
using Multishop.Comment.Data.Context;
using Multishop.Comment.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Comment.Repositories.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CommentMicroserviceContext db;
        public CommentRepository(CommentMicroserviceContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(Data.Entities.Comment entity)
        {
            try
            {
                db.Entry<Data.Entities.Comment>(entity).State = EntityState.Added;
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Data.Entities.Comment entity)
        {
            try
            {
                entity.IsActive = false;
                db.Entry<Data.Entities.Comment>(entity).State = EntityState.Modified;
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Data.Entities.Comment entity)
        {
            try
            {
                db.Entry<Data.Entities.Comment>(entity).State = EntityState.Modified;
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Data.Entities.Comment> GetFirstOrDefaultAsync(Expression<Func<Data.Entities.Comment, bool>> expression)
        {
            try
            {
                return await db.Comments.Where(comment => comment.IsActive == true).FirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Data.Entities.Comment>> GetAllWhereAsync(Expression<Func<Data.Entities.Comment, bool>> expression)
        {
            try
            {
                return await db.Comments.Where(expression).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Data.Entities.Comment>> GetAllAsync()
        {
            try
            {
                return await db.Comments.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}