namespace Multishop.Discount.Dtos
{
    public class CouponDetailDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}