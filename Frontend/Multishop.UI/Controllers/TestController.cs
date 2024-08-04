using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Services.CategoryServices.Abstract;

namespace Multishop.UI.Controllers
{
    public class TestController : Controller
    {
        private readonly ICategoryService categoryService;
        public TestController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categoryVMs = await categoryService.GetAllAsync();
            return View(categoryVMs);
        }
    }
}