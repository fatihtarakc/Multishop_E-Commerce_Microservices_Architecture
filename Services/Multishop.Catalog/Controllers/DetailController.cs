using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.DetailDtos;
using Multishop.Catalog.Services.Abstract;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var detailsListDto = await detailService.GetAllAsync();
            if (detailsListDto is null) return NotFound("In system, detail has not been yet !");

            return Ok(detailsListDto);
        }

        [HttpGet("GetBy/{detailId}")]
        public async Task<IActionResult> GetBy(string detailId)
        {
            var detailDetailDto = await detailService.GetFirstOrDefaultAsync(detail => detail.Id == detailId);
            if (detailDetailDto is null) return NotFound();

            return Ok(detailDetailDto);
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