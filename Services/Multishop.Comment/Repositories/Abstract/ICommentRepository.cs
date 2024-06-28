using System.Linq.Expressions;

namespace Multishop.Comment.Repositories.Abstract
{
    public interface ICommentRepository
    {
        Task<bool> AddAsync(Data.Entities.Comment entity);
        Task<bool> DeleteAsync(Data.Entities.Comment entity);
        Task<bool> UpdateAsync(Data.Entities.Comment entity);
        Task<Data.Entities.Comment> GetFirstOrDefaultAsync(Expression<Func<Data.Entities.Comment, bool>> expression);
        Task<IEnumerable<Data.Entities.Comment>> GetAllWhereAsync(Expression<Func<Data.Entities.Comment, bool>> expression);
        Task<IEnumerable<Data.Entities.Comment>> GetAllAsync();
    }
}