namespace Multishop.UI.Areas.Admin.Models.ViewModels.CategoryVMs
{
    public class CategoryProductsVM
    {
        public CategoryProductsVM()
        {
            ProductVMs = new List<UI.Models.ViewModels.ProductVMs.ProductVM>();
        }

        public UI.Models.ViewModels.CategoryVMs.CategoryVM CategoryVM { get; set; }
        public IEnumerable<UI.Models.ViewModels.ProductVMs.ProductVM> ProductVMs { get; set; }
    }
}