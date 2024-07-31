using Microsoft.AspNetCore.Mvc;
using Multishop.Basket.Dtos.BasketDtos;
using Multishop.Basket.Services.BasketServices;
using Multishop.Basket.Services.LoginServices;

namespace Multishop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly ILoginService loginService;
        public BasketController(IBasketService basketService, ILoginService loginService)
        {
            this.basketService = basketService;
            this.loginService = loginService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var user = User.Claims;
            var basket = await basketService.GetByAsync(loginService.GetUserId);
            if (basket is null) return NotFound("Basket is not found !");

            return Ok(basket);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(BasketDto basketDto)
        {
            basketDto.UserId = loginService.GetUserId;
            bool wasSaved = await basketService.SaveChangesAsync(basketDto);
            if (!wasSaved) return BadRequest("Basket saving process is unsuccess !");

            return Ok("Basket was saved successfully !");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete()
        {
            bool wasDeleted = await basketService.DeleteAsync(loginService.GetUserId);
            if (!wasDeleted) return BadRequest("Basket deleted process is unsuccess !");

            return Ok("Basket was deleted successfully !");
        }
    }
}