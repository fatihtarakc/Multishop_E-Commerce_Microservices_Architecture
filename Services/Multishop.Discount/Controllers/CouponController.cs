using Microsoft.AspNetCore.Mvc;
using Multishop.Discount.Dtos;
using Multishop.Discount.Services.Abstract;

namespace Multishop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService couponService;
        public CouponController(ICouponService couponService)
        {
            this.couponService = couponService;
        }

        [HttpGet("Coupons")]
        public async Task<IActionResult> Coupons()
        {
            var couponsListDto = await couponService.GetAllAsync();
            if (couponsListDto is null) return NotFound("In system, coupon has not been yet !");

            return Ok(couponsListDto);
        }

        [HttpGet("GetBy/{couponId}")]
        public async Task<IActionResult> GetBy(Guid couponId)
        {
            var couponDetailDto = await couponService.GetByAsync(couponId);
            if (couponDetailDto is null) return NotFound();

            return Ok(couponDetailDto);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CouponAddDto couponAddDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            bool isAdded = await couponService.AddAsync(couponAddDto);
            if (!isAdded) return BadRequest("New coupon added process is unsuccess !");

            return Ok("New coupon was added successfully !");
        }

        [HttpDelete("Delete/{couponId}")]
        public async Task<IActionResult> Delete(Guid couponId)
        {
            bool isDeleted = await couponService.DeleteAsync(couponId);
            if (!isDeleted) return BadRequest("Coupon deleted process is unsuccess !");

            return Ok("Coupon was deleted successfully !");
        }

        [HttpPut("Update/{couponId},{isActive}")]
        public async Task<IActionResult> Update(Guid couponId, bool isActive)
        {
            bool isUpdated = await couponService.UpdateAsync(couponId, isActive);
            if (!isUpdated) return BadRequest("Coupon updated process is unsuccess !");

            return Ok("Coupon was updated successfully !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CouponUpdateDto couponUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            bool isUpdated = await couponService.UpdateAsync(couponUpdateDto);
            if (!isUpdated) return BadRequest("Coupon updated process is unsuccess !");

            return Ok("Coupon was updated successfully !");
        }
    }
}