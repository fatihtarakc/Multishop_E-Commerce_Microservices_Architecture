using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Services.BasketServices.Abstract;
using Multishop.UI.Services.CategoryServices.Abstract;
using Multishop.UI.Services.IdentityServices.Abstract;

namespace Multishop.UI.ViewComponents.Layout
{
    public class _NavbarPartial : ViewComponent
    {
        private readonly IIdentityService identityService;
        private readonly IBasketService basketService;
        private readonly ICategoryService categoryService;
        public _NavbarPartial(IIdentityService identityService, IBasketService basketService, ICategoryService categoryService)
        {
            this.identityService = identityService;
            this.basketService = basketService;
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryVMs = await categoryService.GetAllAsync();
            
            if (identityService.GetUserId() is null) return View(categoryVMs);

            var basketVM = await basketService.GetFirstOrDefaultAsync();
            if (basketVM is null) return View(categoryVMs);

            var productAmount = basketVM.Products.Sum(product => product.Amount);
            ViewBag.ProductAmount = productAmount;
            return View(categoryVMs);
        }
    }
}