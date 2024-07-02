using Multishop.UI.Models.ViewModels.CommentVMs;
using Multishop.UI.Models.ViewModels.DetailVMs;
using Multishop.UI.Models.ViewModels.ImageVMs;

namespace Multishop.UI.Models.ViewModels.ProductVMs
{
    public class ProductWithDetailImagesCommentVM
    {
        public ProductWithDetailImagesCommentVM()
        {
            ImageVMs = new List<ImageVM>();
            CommentVMs = new List<CommentVM>();
            CommentAddVM = new();
        }

        public ProductVM ProductVM { get; set; }
        public DetailVM DetailVM { get; set; }
        public IEnumerable<ImageVM> ImageVMs { get; set; }
        public IEnumerable<CommentVM> CommentVMs { get; set; }
        public CommentAddVM CommentAddVM { get; set; }
    }
}