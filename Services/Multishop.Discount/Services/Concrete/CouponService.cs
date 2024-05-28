using Mapster;
using Multishop.Discount.Data.Entities;
using Multishop.Discount.Dtos;
using Multishop.Discount.Repostories.Abstract;
using Multishop.Discount.Services.Abstract;

namespace Multishop.Discount.Services.Concrete
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository couponRepository;
        public CouponService(ICouponRepository couponRepository)
        {
            this.couponRepository = couponRepository;
        }

        public async Task<bool> AddAsync(CouponAddDto couponAddDto)
        {
            var coupon = couponAddDto.Adapt<Coupon>();
            return await couponRepository.AddAsync(coupon);
        }

        public async Task<bool> DeleteAsync(Guid couponId)
        {
            return await couponRepository.DeleteAsync(couponId);
        }

        public async Task<bool> UpdateAsync(Guid couponId, bool isActive)
        {
            return await couponRepository.UpdateAsync(couponId, isActive);
        }

        public async Task<bool> UpdateAsync(CouponUpdateDto couponUpdateDto)
        {
            var coupon = couponUpdateDto.Adapt<Coupon>();
            return await couponRepository.UpdateAsync(coupon);
        }

        public async Task<CouponDetailDto> GetByAsync(Guid couponId)
        {
            var coupon = await couponRepository.GetByAsync(couponId);
            return coupon.Adapt<CouponDetailDto>();
        }

        public async Task<IEnumerable<CouponListDto>> GetAllAsync()
        {
            var coupons = await couponRepository.GetAllAsync();
            return coupons.Adapt<IEnumerable<CouponListDto>>();
        }
    }
}