using Multishop.UI.Areas.Admin.Models.ViewModels.ImageVMs;

namespace Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs
{
    public class ProductUpdateVM
    {
        public ProductUpdateVM()
        {
            ImageUpdateVMs = new List<ImageUpdateVM>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Relations
        public string CategoryId { get; set; }
        public string? DetailId { get; set; }
        public IEnumerable<ImageUpdateVM> ImageUpdateVMs { get; set; }
    }
}