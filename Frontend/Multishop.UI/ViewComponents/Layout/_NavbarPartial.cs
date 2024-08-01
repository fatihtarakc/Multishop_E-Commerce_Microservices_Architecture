using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Services.Abstract;

namespace Multishop.UI.ViewComponents.Layout
{
    public class _NavbarPartial : ViewComponent
    {
        private readonly ICategoryService categoryService;
        public _NavbarPartial(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryVMs = await categoryService.GetAllAsync();
            return View(categoryVMs);
        }
    }
}