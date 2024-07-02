using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.CommentVMs;
using Multishop.UI.Models.ViewModels.DetailVMs;
using Multishop.UI.Models.ViewModels.ImageVMs;
using Multishop.UI.Models.ViewModels.ProductVMs;
using Newtonsoft.Json;
using System.Text;

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

                responseMessage = await client.GetAsync($"https://localhost:7006/api/Comment/CommentsGetBy/{productVM.Id}");
                if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

                jsonData = await responseMessage.Content.ReadAsStringAsync();
                var commentVMs = JsonConvert.DeserializeObject<IEnumerable<CommentVM>>(jsonData);

                var productWithImagesVM = new ProductWithImagesVM()
                {
                    Id = productVM.Id,
                    Name = productVM.Name,
                    Price = productVM.Price,
                    ImageVMs = imageVMs,
                    ProductCommentCount = 0,
                    ProductCommentRatingAverage = 0
                };
                if (commentVMs.Count() is not 0)
                {
                    productWithImagesVM.ProductCommentCount = commentVMs.Count();

                    decimal commentRatingSum = 0;
                    foreach (var commentVM in commentVMs)
                    {
                        commentRatingSum += commentVM.Rating;
                    }
                    productWithImagesVM.ProductCommentRatingAverage = commentRatingSum / commentVMs.Count();
                }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommentAdd(CommentAddVM commentAddVM)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Home", new { area = "" });

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(commentAddVM);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7006/api/Comment/Add", stringContent);
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("Index", "Home", new { area = "" });

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}