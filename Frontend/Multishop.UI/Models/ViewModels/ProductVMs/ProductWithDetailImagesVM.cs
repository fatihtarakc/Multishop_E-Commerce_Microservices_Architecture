using Multishop.UI.Models.ViewModels.DetailVMs;
using Multishop.UI.Models.ViewModels.ImageVMs;

namespace Multishop.UI.Models.ViewModels.ProductVMs
{
    public class ProductWithDetailImagesVM
    {
        public ProductWithDetailImagesVM()
        {
            ImageVMs = new List<ImageVM>();
        }

        public ProductVM ProductVM { get; set; }
        public DetailVM DetailVM { get; set; }
        public IEnumerable<ImageVM> ImageVMs { get; set; }
    }
}