using Multishop.Discount.Dtos;

namespace Multishop.Discount.Services.Abstract
{
    public interface ICouponService
    {
        Task<bool> AddAsync(CouponAddDto couponAddDto);
        Task<bool> DeleteAsync(Guid couponId);
        Task<bool> UpdateAsync(Guid couponId, bool isActive);
        Task<bool> UpdateAsync(CouponUpdateDto couponUpdateDto);
        Task<CouponDetailDto> GetByAsync(Guid couponId);
        Task<IEnumerable<CouponListDto>> GetAllAsync();
    }
}