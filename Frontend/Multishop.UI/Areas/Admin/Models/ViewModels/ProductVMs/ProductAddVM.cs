using Multishop.UI.Areas.Admin.Models.ViewModels.ImageVMs;

namespace Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs
{
    public class ProductAddVM
    {
        public ProductAddVM()
        {
            ImageAddVMs = new List<ImageAddVM>();
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

        // Relations
        public string CategoryId { get; set; }
        public string? DetailId { get; set; }
        public IEnumerable<ImageAddVM> ImageAddVMs { get; set; }
    }
}