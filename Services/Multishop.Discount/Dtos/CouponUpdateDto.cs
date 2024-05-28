namespace Multishop.Discount.Dtos
{
    public class CouponUpdateDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}