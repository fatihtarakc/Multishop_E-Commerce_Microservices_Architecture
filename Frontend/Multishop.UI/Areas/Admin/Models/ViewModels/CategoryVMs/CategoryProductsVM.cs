using Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs;

namespace Multishop.UI.Areas.Admin.Models.ViewModels.CategoryVMs
{
    public class CategoryProductsVM
    {
        public CategoryProductsVM()
        {
            ProductVMs = new List<ProductVM>();
        }

        public CategoryVM CategoryVM { get; set; }
        public IEnumerable<ProductVM> ProductVMs { get; set; }
    }
}