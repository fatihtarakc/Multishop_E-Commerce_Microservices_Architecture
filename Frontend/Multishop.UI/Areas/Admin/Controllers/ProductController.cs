using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.UI.Areas.Admin.Models.ViewModels.DetailVMs;
using Multishop.UI.Areas.Admin.Models.ViewModels.ImageVMs;
using Multishop.UI.Areas.Admin.Models.ViewModels.ProductVMs;
using Multishop.UI.Services.CategoryServices.Abstract;
using Multishop.UI.Services.CommentServices.Abstract;
using Multishop.UI.Services.DetailServices.Abstract;
using Multishop.UI.Services.ImageServices.Abstract;
using Multishop.UI.Services.ProductServices.Abstract;

namespace Multishop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ICommentService commentService;
        private readonly IDetailService detailService;
        private readonly IImageService imageService;
        public ProductController(IProductService productService, ICategoryService categoryService, ICommentService commentService, IDetailService detailService, IImageService imageService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.commentService = commentService;
            this.detailService = detailService;
            this.imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            var productVMs = await productService.GetAllAsync();
            return View(productVMs);
        }

        public async Task<IActionResult> Add()
        {
            var categoryVMs = await categoryService.GetAllAsync();
            if (categoryVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

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
            var categoryVMs = await categoryService.GetAllAsync();
            if (categoryVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            IEnumerable<SelectListItem> categories = (from category in categoryVMs
                                                      select new SelectListItem
                                                      {
                                                          Value = category.Id,
                                                          Text = category.Name
                                                      }).ToList();
            ViewBag.Categories = categories;

            if (!ModelState.IsValid) return View(productAddVM);

            bool response = await productService.AddAsync(productAddVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/Delete/{productId}")]
        public async Task<IActionResult> Delete(string productId)
        {
            bool response = await productService.DeleteAsync(productId);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/Update/{productId}")]
        public async Task<IActionResult> Update(string productId)
        {
            var categoryVMs = await categoryService.GetAllAsync();
            if (categoryVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            IEnumerable<SelectListItem> categories = (from category in categoryVMs
                                                      select new SelectListItem
                                                      {
                                                          Value = category.Id,
                                                          Text = category.Name
                                                      }).ToList();
            ViewBag.Categories = categories;

            var productUpdateVM = (await productService.GetFirstOrDefaultAsync(productId)).Adapt<ProductUpdateVM>();
            if (productUpdateVM is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            return View(productUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductUpdateVM productUpdateVM)
        {
            var categoryVMs = await categoryService.GetAllAsync();
            if (categoryVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            IEnumerable<SelectListItem> categories = (from category in categoryVMs
                                                      select new SelectListItem
                                                      {
                                                          Value = category.Id,
                                                          Text = category.Name
                                                      }).ToList();
            ViewBag.Categories = categories;

            if (!ModelState.IsValid) return View(productUpdateVM);

            bool response = await productService.UpdateAsync(productUpdateVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/Detail/{productId}")]
        public async Task<IActionResult> Detail(string productId)
        {
            var detailVM = await detailService.GetFirstOrDefaultAsync(productId);
            ViewBag.ProductId = productId;

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

            bool response = await detailService.AddAsync(detailAddVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/DetailDelete/{detailId}")]
        public async Task<IActionResult> DetailDelete(string detailId)
        {
            bool response = await detailService.DeleteAsync(detailId);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/DetailUpdate/{productId}")]
        public async Task<IActionResult> DetailUpdate(string productId)
        {
            var detailUpdateVM = (await detailService.GetFirstOrDefaultAsync(productId)).Adapt<DetailUpdateVM>();
            if (detailUpdateVM is null) return RedirectToAction("NotFound", "Home", new { area = "" });
            detailUpdateVM.ProductId = productId;

            return View(detailUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailUpdate(DetailUpdateVM detailUpdateVM)
        {
            if (!ModelState.IsValid) return View(detailUpdateVM);

            bool response = await detailService.UpdateAsync(detailUpdateVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/Images/{productId}")]
        public async Task<IActionResult> Images(string productId)
        {
            var imageVMs = await imageService.GetAllByAsync(productId);
            if (imageVMs is null) return RedirectToAction("NotFound", "Home", new { area = "" });
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

            bool response = await imageService.AddAsync(imageAddVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/ImageDelete/{imageId}")]
        public async Task<IActionResult> ImageDelete(string imageId)
        {
            bool response = await imageService.DeleteAsync(imageId);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/ImageUpdate/{imageId}")]
        public async Task<IActionResult> ImageUpdate(string imageId)
        {
            var imageUpdateVM = (await productService.GetFirstOrDefaultAsync(imageId)).Adapt<Areas.Admin.Models.ViewModels.ImageVMs.ImageUpdateVM>();
            if (imageUpdateVM is null) return RedirectToAction("NotFound", "Home", new { area = "" });

            return View(imageUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImageUpdate(ImageUpdateVM imageUpdateVM)
        {
            if (!ModelState.IsValid) return View(imageUpdateVM);

            bool response = await imageService.UpdateAsync(imageUpdateVM);
            if (!response) return RedirectToAction("NotFound", "Home", new { area = "" });

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Product/Comments/{productId},{productName}")]
        public async Task<IActionResult> Comments(string productId, string productName)
        {
            var commentVMs = await commentService.GetAllByAsync(productId);
            ViewBag.ProductName = productName;

            return View(commentVMs);
        }
    }
}