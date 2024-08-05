using Multishop.UI.Models.ViewModels.CommentVMs;

namespace Multishop.UI.Services.CommentServices.Abstract
{
    public interface ICommentService
    {
        Task<bool> AddAsync(CommentAddVM commentAddVM);
        Task<IEnumerable<CommentVM>> GetAllByAsync(string productId);
    }
}