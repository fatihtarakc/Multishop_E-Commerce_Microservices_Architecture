using Mapster;
using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Areas.Admin.Models.ViewModels.CategoryVMs;
using Multishop.UI.Services.Abstract;
using Newtonsoft.Json;
using System.Text;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        private readonly IHttpClientFactory httpClientFactory;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
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

            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Product/ProductsGetBy/{categoryId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var productVMs = JsonConvert.DeserializeObject<IEnumerable<UI.Models.ViewModels.ProductVMs.ProductVM>>(jsonData);

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
            if (!response) ModelState.AddModelError("Error", "Something went wrong !");

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
            if (!response) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }
    }
}