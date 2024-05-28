using Multishop.Discount.Data.Entities;

namespace Multishop.Discount.Repostories.Abstract
{
    public interface ICouponRepository
    {
        Task<bool> AddAsync(Coupon coupon);
        Task<bool> DeleteAsync(Guid couponId);
        Task<bool> UpdateAsync(Guid couponId, bool isActive);
        Task<bool> UpdateAsync(Coupon coupon);
        Task<Coupon> GetByAsync(Guid couponId);
        Task<IEnumerable<Coupon>> GetAllAsync();
    }
}