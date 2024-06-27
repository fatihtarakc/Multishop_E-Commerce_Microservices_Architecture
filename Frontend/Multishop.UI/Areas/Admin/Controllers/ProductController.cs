using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.UI.Areas.Admin.Models.ViewModels.CategoryVMs;
using Multishop.UI.Areas.Admin.Models.ViewModels.DetailVMs;
using Multishop.UI.Areas.Admin.Models.ViewModels.ImageVMs;
using Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Product/Products");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var productVMs = JsonConvert.DeserializeObject<IEnumerable<ProductVM>>(jsonData);
            return View(productVMs);
        }

        public async Task<IActionResult> Add()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Category/Categories");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoryVMs = JsonConvert.DeserializeObject<IEnumerable<CategoryVM>>(jsonData);
            IEnumerable<SelectListItem> categories = (from category in categoryVMs
                                                      select new SelectListItem
                                                      {
                                                          Value = category.Id,
                                                          Text = category.Name
                                                      }).ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProductAddVM productAddVM)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Category/Categories");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoryVMs = JsonConvert.DeserializeObject<IEnumerable<CategoryVM>>(jsonData);
            IEnumerable<SelectListItem> categories = (from category in categoryVMs
                                                      select new SelectListItem
                                                      {
                                                          Value = category.Id,
                                                          Text = category.Name
                                                      }).ToList();
            ViewBag.Categories = categories;

            if (ModelState.IsValid)
            {
                client = httpClientFactory.CreateClient();
                jsonData = JsonConvert.SerializeObject(productAddVM);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                responseMessage = await client.PostAsync("https://localhost:7001/api/Product/Add", stringContent);
                if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

                return RedirectToAction("Index");
            }

            return View(productAddVM);
        }

        [HttpGet("Admin/Product/Delete/{productId}")]
        public async Task<IActionResult> Delete(string productId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Product/Delete/{productId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/Update/{productId}")]
        public async Task<IActionResult> Update(string productId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Category/Categories");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoryVMs = JsonConvert.DeserializeObject<IEnumerable<CategoryVM>>(jsonData);
            IEnumerable<SelectListItem> categories = (from category in categoryVMs
                                                      select new SelectListItem
                                                      {
                                                          Value = category.Id,
                                                          Text = category.Name
                                                      }).ToList();
            ViewBag.Categories = categories;

            client = httpClientFactory.CreateClient();
            responseMessage = await client.GetAsync($"https://localhost:7001/api/Product/GetBy/{productId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            jsonData = await responseMessage.Content.ReadAsStringAsync();
            var productUpdateVM = JsonConvert.DeserializeObject<ProductUpdateVM>(jsonData);
            return View(productUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductUpdateVM productUpdateVM)
        {
            if (!ModelState.IsValid) return View(productUpdateVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(productUpdateVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7001/api/Product/Update", stringContent);
            if (!responseMessage.IsSuccessStatusCode) ModelState.AddModelError("Error", "Something went wrong !");

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/Detail/{productId}")]
        public async Task<IActionResult> Detail(string productId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Detail/GetBy/{productId}");
            if (!(responseMessage.StatusCode == HttpStatusCode.OK || responseMessage.StatusCode == HttpStatusCode.NotFound)) return RedirectToAction("NotFound", "Home", new { area = "" });

            ViewBag.ProductId = productId;
            if (responseMessage.StatusCode == HttpStatusCode.NotFound) return View();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var detailVM = JsonConvert.DeserializeObject<DetailVM>(jsonData);
            return View(detailVM);
        }

        [HttpGet("Admin/Product/DetailAdd/{productId}")]
        public IActionResult DetailAdd(string productId)
        {
            var detailAddVM = new DetailAddVM()
            {
                ProductId = productId
            };
            return View(detailAddVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailAdd(DetailAddVM detailAddVM)
        {
            if (!ModelState.IsValid) return View(detailAddVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(detailAddVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7001/api/Detail/Add", stringContent);
            if (!responseMessage.IsSuccessStatusCode)
            {
                ModelState.AddModelError("Error", "Something went wrong !");
                return View(detailAddVM);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/DetailDelete/{detailId}")]
        public async Task<IActionResult> DetailDelete(string detailId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Detail/Delete/{detailId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/DetailUpdate/{productId}")]
        public async Task<IActionResult> DetailUpdate(string productId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Detail/GetBy/{productId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var detailVM = JsonConvert.DeserializeObject<DetailVM>(jsonData);

            var detailUpdateVM = detailVM.Adapt<DetailUpdateVM>();
            detailUpdateVM.ProductId = productId;
            return View(detailUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailUpdate(DetailUpdateVM detailUpdateVM)
        {
            if (!ModelState.IsValid) return View(detailUpdateVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(detailUpdateVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7001/api/Detail/Update", stringContent);
            if (!responseMessage.IsSuccessStatusCode)
            {
                ModelState.AddModelError("Error", "Something went wrong !");
                return View(detailUpdateVM);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/Images/{productId}")]
        public async Task<IActionResult> Images(string productId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Image/ImagesGetBy/{productId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var imageVMs = JsonConvert.DeserializeObject<IEnumerable<ImageVM>>(jsonData);
            ViewBag.ProductId = productId;
            return View(imageVMs);
        }

        [HttpGet("Admin/Product/ImageAdd/{productId}")]
        public IActionResult ImageAdd(string productId)
        {
            var imageAddVM = new ImageAddVM()
            {
                ProductId = productId
            };
            return View(imageAddVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImageAdd(ImageAddVM imageAddVM)
        {
            if (!ModelState.IsValid) return View(imageAddVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(imageAddVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7001/api/Image/Add", stringContent);
            if (!responseMessage.IsSuccessStatusCode)
            {
                ModelState.AddModelError("Error", "Something went wrong !");
                return View(imageAddVM);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/ImageDelete/{imageId}")]
        public async Task<IActionResult> ImageDelete(string imageId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Image/Delete/{imageId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/ImageUpdate/{imageId}")]
        public async Task<IActionResult> ImageUpdate(string imageId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Image/GetBy/{imageId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var imageVM = JsonConvert.DeserializeObject<ImageVM>(jsonData);

            var imageUpdateVM = new ImageUpdateVM()
            {
                Id = imageVM.Id,
                Url = imageVM.Url,
                ProductId = imageVM.ProductId
            };
            return View(imageUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImageUpdate(ImageUpdateVM imageUpdateVM)
        {
            if (!ModelState.IsValid) return View(imageUpdateVM);

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(imageUpdateVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7001/api/Image/Update", stringContent);
            if (!responseMessage.IsSuccessStatusCode)
            {
                ModelState.AddModelError("Error", "Something went wrong !");
                return View(imageUpdateVM);
            }

            return RedirectToAction("Index");
        }
    }
}