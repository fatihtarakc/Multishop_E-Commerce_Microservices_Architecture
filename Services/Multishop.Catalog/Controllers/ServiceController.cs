using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.ServiceDtos;
using Multishop.Catalog.Services.Abstract;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService serviceService;
        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [HttpGet("Services")]
        public async Task<IActionResult> Services() 
        {
            var serviceDtos = await serviceService.GetAllAsync();
            if (serviceDtos is null) return NotFound("In system, service has not been yet !");

            return Ok(serviceDtos);
        }

        [HttpGet("GetBy/{serviceId}")]
        public async Task<IActionResult> GetBy(string serviceId)
        {
            var serviceDto = await serviceService.GetFirstOrDefaultAsync(service => service.Id == serviceId);
            if (serviceDto is null) return NotFound();

            return Ok(serviceDto);
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ServiceAddDto serviceAddDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await serviceService.AddAsync(serviceAddDto);
            return Ok($"{serviceAddDto.Name} was added successfully !");
        }

        [Authorize]
        [HttpDelete("Delete/{serviceId}")]
        public async Task<IActionResult> Delete(string serviceId)
        {
            if (string.IsNullOrWhiteSpace(serviceId)) return BadRequest("Missing or incorrect entry !");

            await serviceService.DeleteAsync(serviceId);
            return Ok("This service was deleted successfully !");
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(ServiceUpdateDto serviceUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await serviceService.UpdateAsync(serviceUpdateDto);
            return Ok($"{serviceUpdateDto.Name} was updated successfully !");
        }
    }
}