using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.DetailDtos;
using Multishop.Catalog.Services.Abstract;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [AllowAnonymous]
    public class DetailController : ControllerBase
    {
        private readonly IDetailService detailService;
        public DetailController(IDetailService detailService)
        {
            this.detailService = detailService;
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details()
        {
            var detailDtos = await detailService.GetAllAsync();
            if (detailDtos is null) return NotFound("In system, detail has not been yet !");

            return Ok(detailDtos);
        }

        [HttpGet("GetBy/{productId}")]
        public async Task<IActionResult> GetBy(string productId)
        {
            var detailDto = await detailService.GetFirstOrDefaultAsync(detail => detail.ProductId == productId);
            if (detailDto is null) return NotFound();

            return Ok(detailDto);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(DetailAddDto detailAddDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrcet entry !");

            await detailService.AddAsync(detailAddDto);
            return Ok($"{detailAddDto.Description} was added successfully !");
        }

        [HttpDelete("Delete/{detailId}")]
        public async Task<IActionResult> Delete(string detailId)
        {
            if (string.IsNullOrWhiteSpace(detailId)) return BadRequest("Missing or incorrect entry !");

            await detailService.DeleteAsync(detailId);
            return Ok("This detail was deleted successfully !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(DetailUpdateDto detailUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await detailService.UpdateAsync(detailUpdateDto);
            return Ok($"{detailUpdateDto.Description} was updated successfully !");
        }
    }
}