using Multishop.Basket.Dtos.ProductDtos;

namespace Multishop.Basket.Dtos.BasketDtos
{
    public class BasketDto
    {
        public BasketDto() 
        {
            ProductDtos = new List<ProductDto>();
        }

        public string UserId { get; set; }
        public string? DiscountCouponCode { get; set; }
        public int? DiscountCouponRate { get; set; }
        public decimal TotalPrice => ProductDtos.Sum(product => product.Amount * product.Price);
        public DateTime CreationDate { get; set; } = DateTime.Now;

        // Relations
        public IEnumerable<ProductDto> ProductDtos { get; set; }
    }
}