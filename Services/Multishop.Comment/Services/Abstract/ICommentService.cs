using Multishop.Comment.Dtos.CommentDtos;
using System.Linq.Expressions;

namespace Multishop.Comment.Services.Abstract
{
    public interface ICommentService
    {
        Task<bool> AddAsync(CommentAddDto entityAddDto);
        Task<bool> DeleteAsync(Guid commentId);
        Task<bool> UpdateAsync(CommentUpdateDto entityUpdateDto);
        Task<CommentDto> GetFirstOrDefaultAsync(Expression<Func<Data.Entities.Comment, bool>> expression);
        Task<IEnumerable<CommentDto>> GetAllWhereAsync(Expression<Func<Data.Entities.Comment, bool>> expression);
        Task<IEnumerable<CommentDto>> GetAllAsync();
    }
}