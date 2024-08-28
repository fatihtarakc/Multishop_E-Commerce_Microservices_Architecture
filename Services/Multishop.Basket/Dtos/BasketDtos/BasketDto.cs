using Multishop.Basket.Dtos.ProductDtos;

namespace Multishop.Basket.Dtos.BasketDtos
{
    public class BasketDto
    {
        public BasketDto()
        {
            Products = new List<ProductDto>();
        }

        public string UserId { get; set; }
        public string? DiscountCouponCode { get; set; }
        public int? DiscountCouponRate { get; set; }
        public decimal TotalPrice => Products.Sum(product => product.TotalPrice);
        public DateTime CreationDate => DateTime.Now;

        // Relations
        public IEnumerable<ProductDto> Products { get; set; }
    }
}