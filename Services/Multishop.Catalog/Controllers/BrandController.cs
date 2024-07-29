using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.BrandDtos;
using Multishop.Catalog.Services.Abstract;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;
        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet("Brands")]
        public async Task<IActionResult> Brands()
        {
            var brandDtos = await brandService.GetAllAsync();
            if (brandDtos is null) return NotFound("In system, brand has not been yet !");

            return Ok(brandDtos);
        }

        [HttpGet("GetBy/{brandId}")]
        public async Task<IActionResult> GetBy(string brandId)
        {
            var brandDto = await brandService.GetFirstOrDefaultAsync(brand => brand.Id == brandId);
            if (brandDto is null) return NotFound();

            return Ok(brandDto);
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(BrandAddDto brandAddDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await brandService.AddAsync(brandAddDto);
            return Ok($"{brandAddDto.Name} was added successfuly !");
        }

        [Authorize]
        [HttpDelete("Delete/{brandId}")]
        public async Task<IActionResult> Delete(string brandId)
        {
            if (string.IsNullOrWhiteSpace(brandId)) return BadRequest("Missing or incorrect entry !");

            await brandService.DeleteAsync(brandId);
            return Ok("This brand was deleted successfully !");
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(BrandUpdateDto brandUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await brandService.UpdateAsync(brandUpdateDto);
            return Ok($"{brandUpdateDto.Name} was updated successfully !");
        }
    }
}