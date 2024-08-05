using Mapster;
using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.CategoryVMs;
using Multishop.UI.Services.CategoryServices.Abstract;
using Multishop.UI.Services.ProductServices.Abstract;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var categoryVMs = await categoryService.GetAllAsync();
            return View(categoryVMs);
        }

        [HttpGet("Admin/Category/Detail/{categoryId}")]
        public async Task<IActionResult> Detail(string categoryId)
        {
            var categoryVM = await categoryService.GetFirstOrDefaultAsync(categoryId);
            if (categoryVM is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            var productVMs = await productService.GetAllByAsync(categoryId);
            if (productVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            var categoryProductsVM = new CategoryProductsVM();
            categoryProductsVM.CategoryVM = categoryVM;
            categoryProductsVM.ProductVMs = productVMs;
            return View(categoryProductsVM);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CategoryAddVM categoryAddVM)
        {
            if (!ModelState.IsValid) return View(categoryAddVM);

            bool response = await categoryService.AddAsync(categoryAddVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Category/Delete/{categoryId}")]
        public async Task<IActionResult> Delete(string categoryId)
        {
            bool response = await categoryService.DeleteAsync(categoryId);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Category/Update/{categoryId}")]
        public async Task<IActionResult> Update(string categoryId)
        {
            var categoryUpdateVM = (await categoryService.GetFirstOrDefaultAsync(categoryId)).Adapt<CategoryUpdateVM>();
            if (categoryUpdateVM is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            return View(categoryUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CategoryUpdateVM categoryUpdateVM)
        {
            if (!ModelState.IsValid) return View(categoryUpdateVM);

            bool response = await categoryService.UpdateAsync(categoryUpdateVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }
    }
}