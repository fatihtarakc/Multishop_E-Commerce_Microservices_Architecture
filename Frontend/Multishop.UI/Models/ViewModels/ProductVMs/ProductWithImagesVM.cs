using Multishop.UI.Models.ViewModels.ImageVMs;

namespace Multishop.UI.Models.ViewModels.ProductVMs
{
    public class ProductWithImagesVM
    {
        public ProductWithImagesVM() 
        {
            ImageVMs = new List<ImageVM>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductCommentCount { get; set; }
        public decimal ProductCommentRatingAverage { get; set; }

        // Relations
        public IEnumerable<ImageVM> ImageVMs { get; set; }
    }
}