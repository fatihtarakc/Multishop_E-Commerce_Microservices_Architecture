using Mapster;
using Multishop.Comment.Dtos.CommentDtos;
using Multishop.Comment.Repositories.Abstract;
using Multishop.Comment.Services.Abstract;
using System.Linq.Expressions;

namespace Multishop.Comment.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task<bool> AddAsync(CommentAddDto entityAddDto)
        {
            var comment = entityAddDto.Adapt<Data.Entities.Comment>();
            return await commentRepository.AddAsync(comment);
        }

        public async Task<bool> DeleteAsync(Guid commentId)
        {
            var comment = await commentRepository.GetFirstOrDefaultAsync(comment => comment.Id == commentId);
            if (comment is null) return false;

            return await commentRepository.DeleteAsync(comment);
        }

        public async Task<bool> UpdateAsync(CommentUpdateDto entityUpdateDto)
        {
            var comment = await commentRepository.GetFirstOrDefaultAsync(comment => comment.Id == entityUpdateDto.Id);
            if (comment is null) return false;

            return await commentRepository.UpdateAsync(entityUpdateDto.Adapt(comment));
        }

        public async Task<CommentDto> GetFirstOrDefaultAsync(Expression<Func<Data.Entities.Comment, bool>> expression)
        {
            return (await commentRepository.GetFirstOrDefaultAsync(expression)).Adapt<CommentDto>();
        }

        public async Task<IEnumerable<CommentDto>> GetAllWhereAsync(Expression<Func<Data.Entities.Comment, bool>> expression)
        {
            return (await commentRepository.GetAllWhereAsync(expression)).Adapt<IEnumerable<CommentDto>>();
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync()
        {
            return (await commentRepository.GetAllAsync()).Adapt<IEnumerable<CommentDto>>();
        }
    }
}