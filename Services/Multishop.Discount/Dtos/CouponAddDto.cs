namespace Multishop.Discount.Dtos
{
    public class CouponAddDto
    {
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}