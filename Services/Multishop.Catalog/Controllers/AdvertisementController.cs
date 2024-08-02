using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.AdvertisementDtos;
using Multishop.Catalog.Services.Abstract;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService advertisementService;
        public AdvertisementController(IAdvertisementService advertisementService)
        {
            this.advertisementService = advertisementService;
        }

        [HttpGet("Advertisements")]
        public async Task<IActionResult> Advertisements()
        {
            var advertisementDtos = await advertisementService.GetAllAsync();
            if (advertisementDtos is null) return NotFound("In system, advertisement has not been yet !");

            return Ok(advertisementDtos);
        }

        [HttpGet("GetBy/{advertisementId}")]
        public async Task<IActionResult> GetBy(string advertisementId)
        {
            var advertisementDto = await advertisementService.GetFirstOrDefaultAsync(advertisement => advertisement.Id == advertisementId);
            if (advertisementDto is null) return NotFound();

            return Ok(advertisementDto);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AdvertisementAddDto advertisementAddDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await advertisementService.AddAsync(advertisementAddDto);
            return Ok($"{advertisementAddDto.Title} was added successfuly !");
        }

        [HttpDelete("Delete/{advertisementId}")]
        public async Task<IActionResult> Delete(string advertisementId)
        {
            if (string.IsNullOrWhiteSpace(advertisementId)) return BadRequest("Missing or incorrect entry !");

            await advertisementService.DeleteAsync(advertisementId);
            return Ok("This advertisement was deleted successfully !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(AdvertisementUpdateDto advertisementUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await advertisementService.UpdateAsync(advertisementUpdateDto);
            return Ok($"{advertisementUpdateDto.Title} was updated successfully !");
        }
    }
}