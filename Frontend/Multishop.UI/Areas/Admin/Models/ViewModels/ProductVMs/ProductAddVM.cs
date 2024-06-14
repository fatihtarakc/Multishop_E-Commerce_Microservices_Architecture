namespace Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs
{
    public class ProductAddVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Relations
        public string CategoryId { get; set; }
    }
}