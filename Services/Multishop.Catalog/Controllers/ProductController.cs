using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Services.Abstract;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [AllowAnonymous]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("Products")]
        public async Task<IActionResult> Products()
        {
            var productDtos = await productService.GetAllAsync();
            if (productDtos is null) return NotFound("In system, product has not been yet !");

            return Ok(productDtos);
        }

        [HttpGet("ProductsGetBy/{categoryId}")]
        public async Task<IActionResult> ProductsGetBy(string categoryId)
        {
            var productDtosGetByCategoryId = await productService.GetAllWhereAsync(product => product.CategoryId == categoryId);
            if (productDtosGetByCategoryId is null) return NotFound("In system, product by categoryId has not been yet !");

            return Ok(productDtosGetByCategoryId);
        }

        [HttpGet("GetBy/{productId}")]
        public async Task<IActionResult> GetBy(string productId)
        {
            var productDto = await productService.GetFirstOrDefaultAsync(product => product.Id == productId);
            if (productDto is null) return NotFound();

            return Ok(productDto);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await productService.AddAsync(productAddDto);
            return Ok($"{productAddDto.Name} was added successfully !");
        }

        [HttpDelete("Delete/{productId}")]
        public async Task<IActionResult> Delete(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId)) return BadRequest("Missing or incorrect entry !");

            await productService.DeleteAsync(productId);
            return Ok("This product was deleted successfully !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await productService.UpdateAsync(productUpdateDto);
            return Ok($"{productUpdateDto.Name} was updated successfully !");
        }
    }
}