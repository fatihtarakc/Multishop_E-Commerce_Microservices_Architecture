namespace Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs
{
    public class ProductListVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Relations
        public string CategoryId { get; set; }
    }
}