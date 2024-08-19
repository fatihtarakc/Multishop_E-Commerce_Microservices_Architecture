namespace Multishop.UI.Models.ViewModels.BasketVMs
{
    public class BasketVM
    {
        public BasketVM() 
        {
            Products = new List<BasketProductVM>();
        }

        public string UserId { get; set; }
        public string? DiscountCouponCode { get; set; }
        public int? DiscountCouponRate { get; set; }
        public decimal TotalPrice => Products.Sum(product => product.TotalPrice);
        public DateTime CreationDate { get; set; } = DateTime.Now;

        // Relations
        public IEnumerable<BasketProductVM> Products { get; set; }
    }
}