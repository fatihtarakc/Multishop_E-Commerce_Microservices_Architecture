using Microsoft.AspNetCore.Mvc;
using Multishop.UI.Models.ViewModels.CommentVMs;
using Multishop.UI.Models.ViewModels.ProductVMs;
using Multishop.UI.Services.BasketServices.Abstract;
using Multishop.UI.Services.CommentServices.Abstract;
using Multishop.UI.Services.DetailServices.Abstract;
using Multishop.UI.Services.IdentityServices.Abstract;
using Multishop.UI.Services.ImageServices.Abstract;
using Multishop.UI.Services.ProductServices.Abstract;

namespace Multishop.UI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IIdentityService identityService;
        private readonly IBasketService basketService;
        private readonly ICommentService commentService;
        private readonly IDetailService detailService;
        private readonly IImageService imageService;
        private readonly IProductService productService;
        public ShopController(IIdentityService identityService, IBasketService basketService, ICommentService commentService, IDetailService detailService, IImageService imageService, IProductService productService)
        {
            this.identityService = identityService;
            this.basketService = basketService;
            this.commentService = commentService;
            this.detailService = detailService;
            this.imageService = imageService;
            this.productService = productService;
        }

        [HttpGet("/Shop/Index/{categoryId}")]
        public async Task<IActionResult> Index(string categoryId)
        {
            var productVMs = await productService.GetAllByAsync(categoryId);
            if (productVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            var productWithImagesVMs = new List<ProductWithImagesVM>();
            foreach (var productVM in productVMs)
            {
                var imageVMs = await imageService.GetAllByAsync(productVM.Id);
                if (imageVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

                var commentVMs = await commentService.GetAllByAsync(productVM.Id);
                if (commentVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

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
            var productVM = await productService.GetFirstOrDefaultAsync(productId);
            if (productVM is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            var detailVM = await detailService.GetFirstOrDefaultAsync(productId);
            if (detailVM is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            var imageVMs = await imageService.GetAllByAsync(productId);
            if (imageVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            var commentVMs = await commentService.GetAllByAsync(productId);
            if (commentVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

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

            var response = await commentService.AddAsync(commentAddVM);
            if (!response) return RedirectToAction("Index", "Home", new { area = "" });

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public async Task<IActionResult> Cart()
        {
            if (identityService.GetUserId() is null) return RedirectToAction("SignIn", "Account", new { area = "" });

            var basketVM = await basketService.GetFirstOrDefaultAsync();
            return View(basketVM);
        }

        public async Task<IActionResult> IncreaseProductAmountInCart()
        {
            if (identityService.GetUserId() is null) return RedirectToAction("SignIn", "Account", new { area = "" });

            var basketVM = await basketService.GetFirstOrDefaultAsync();
            return View();
        }

        public async Task<IActionResult> DecreaseProductAmountInCart()
        {
            if (identityService.GetUserId() is null) return RedirectToAction("SignIn", "Account", new { area = "" });

            var basketVM = await basketService.GetFirstOrDefaultAsync();
            return View();
        }
    }
}