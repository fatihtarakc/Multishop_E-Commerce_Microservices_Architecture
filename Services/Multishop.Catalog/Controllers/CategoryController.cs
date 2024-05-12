using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Services.Abstract;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> Categories()
        {
            var categoriesListDto = await categoryService.GetAllAsync();
            if (categoriesListDto is null) return NotFound("In system, category has not been yet !");

            return Ok(categoriesListDto);
        }

        [HttpGet("GetBy/{categoryId}")]
        public async Task<IActionResult> GetBy(string categoryId)
        {
            var categoryDetailDto = await categoryService.GetFirstOrDefaultAsync(category => category.Id == categoryId);
            if (categoryDetailDto is null) return NotFound();

            return Ok(categoryDetailDto);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await categoryService.AddAsync(categoryAddDto);
            return Ok($"{categoryAddDto.Name} was added successfuly !");
        }

        [HttpDelete("Delete/{categoryId}")]
        public async Task<IActionResult> Delete(string categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId)) return BadRequest("Missing or incorrect entry !");

            await categoryService.DeleteAsync(categoryId);
            return Ok("This category was deleted successfully !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await categoryService.UpdateAsync(categoryUpdateDto);
            return Ok($"{categoryUpdateDto.Name} was updated successfully !");
        }
    }
}