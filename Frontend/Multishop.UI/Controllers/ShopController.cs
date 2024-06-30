using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.CommentVMs;
using Multishop.UI.Models.ViewModels.DetailVMs;
using Multishop.UI.Models.ViewModels.ImageVMs;
using Multishop.UI.Models.ViewModels.ProductVMs;
using Newtonsoft.Json;

namespace Multishop.UI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ShopController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet("/Shop/Index/{categoryId}")]
        public async Task<IActionResult> Index(string categoryId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Product/ProductsGetBy/{categoryId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var productVMs = JsonConvert.DeserializeObject<IEnumerable<ProductVM>>(jsonData);

            var productWithImagesVMs = new List<ProductWithImagesVM>();
            foreach (var productVM in productVMs)
            {
                responseMessage = await client.GetAsync($"https://localhost:7001/api/Image/ImagesGetBy/{productVM.Id}");
                if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

                jsonData = await responseMessage.Content.ReadAsStringAsync();
                var imageVMs = JsonConvert.DeserializeObject<IEnumerable<ImageVM>>(jsonData);

                var productWithImagesVM = new ProductWithImagesVM()
                {
                    Id = productVM.Id,
                    Name = productVM.Name,
                    Price = productVM.Price,
                    ImageVMs = imageVMs
                };
                productWithImagesVMs.Add(productWithImagesVM);
            }
            return View(productWithImagesVMs);
        }

        [HttpGet("/Shop/ProductDetail/{productId}")]
        public async Task<IActionResult> ProductDetail(string productId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/Product/GetBy/{productId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var productVM = JsonConvert.DeserializeObject<ProductVM>(jsonData);

            responseMessage = await client.GetAsync($"https://localhost:7001/api/Detail/GetBy/{productId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            jsonData = await responseMessage.Content.ReadAsStringAsync();
            var detailVM = JsonConvert.DeserializeObject<DetailVM>(jsonData);

            responseMessage = await client.GetAsync($"https://localhost:7001/api/Image/ImagesGetBy/{productId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            jsonData = await responseMessage.Content.ReadAsStringAsync();
            var imageVMs = JsonConvert.DeserializeObject<IEnumerable<ImageVM>>(jsonData);

            responseMessage = await client.GetAsync($"https://localhost:7006/api/Comment/CommentsGetBy/{productId}");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            jsonData = await responseMessage.Content.ReadAsStringAsync();
            var commentVMs = JsonConvert.DeserializeObject<IEnumerable<CommentVM>>(jsonData);

            var productWithDetailImages = new ProductWithDetailImagesCommentVM()
            {
                ProductVM = productVM,
                DetailVM = detailVM,
                ImageVMs = imageVMs,
                CommentVMs = commentVMs
            };
            return View(productWithDetailImages);
        }
    }
}