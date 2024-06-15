using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.ImageDtos;
using Multishop.Catalog.Services.Abstract;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService imageService;
        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpGet("Images")]
        public async Task<IActionResult> Images()
        {
            var imageDtos = await imageService.GetAllAsync();
            if (imageDtos is null) return NotFound("In system, image has not been yet !");

            return Ok(imageDtos);
        }

        [HttpGet("GetBy/{imageId}")]
        public async Task<IActionResult> GetBy(string imageId)
        {
            var imageDto = await imageService.GetFirstOrDefaultAsync(image => image.Id == imageId);
            if (imageDto is null) return NotFound();

            return Ok(imageDto);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ImageAddDto imageAddDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await imageService.AddAsync(imageAddDto);
            return Ok($"{imageAddDto.Url} was added successfully !");
        }

        [HttpDelete("Delete/{imageId}")]
        public async Task<IActionResult> Delete(string imageId)
        {
            if (string.IsNullOrWhiteSpace(imageId)) return BadRequest("Missing or incorrect entry !");

            await imageService.DeleteAsync(imageId);
            return Ok("This image was deleted successfully !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ImageUpdateDto imageUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await imageService.UpdateAsync(imageUpdateDto);
            return Ok($"{imageUpdateDto.Url} was updated successfully !");
        }
    }
}