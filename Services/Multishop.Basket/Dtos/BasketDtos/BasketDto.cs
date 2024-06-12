namespace Multishop.Basket.Dtos.BasketDtos
{
    public class BasketDto
    {
        public BasketDto() 
        {
            BasketItemDtos = new List<BasketItemDto>();
        }

        public string UserId { get; set; }
        public string? DiscountCouponCode { get; set; }
        public int? DiscountCouponRate { get; set; }
        public decimal TotalPrice => BasketItemDtos.Sum(basket => basket.ProductAmount * basket.ProductPrice);
        public DateTime CreationDate { get; set; } = DateTime.Now;

        // Relations
        public IEnumerable<BasketItemDto> BasketItemDtos { get; set; }
    }
}