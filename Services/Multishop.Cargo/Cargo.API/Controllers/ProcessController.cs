using Cargo.Business.Services.Abstract;
using Cargo.Dto.ProcessDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService processService;
        public ProcessController(IProcessService processService)
        {
            this.processService = processService;
        }

        [HttpGet("Processes")]
        public async Task<IActionResult> Processes()
        {
            var processListDtos = await processService.GetAllAsync();
            return Ok(processListDtos);
        }

        [HttpGet("GetBy/{entityId}")]
        public async Task<IActionResult> GetBy(Guid entityId)
        {
            var process = await processService.GetFirstOrDefaultAsync(process => process.Id == entityId);
            if (process is null) return NotFound("Searching process was not found !");

            return Ok(process);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProcessAddDto entityAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            bool wasAdded = await processService.AddAsync(entityAddDto);
            if (!wasAdded) return BadRequest("New cargo process added process is unsuccess !");

            return Ok("New cargo process was added successfully !");
        }

        [HttpDelete("Delete/{entityId}")]
        public async Task<IActionResult> Delete(Guid entityId)
        {
            bool wasDeleted = await processService.DeleteAsync(entityId);
            if (!wasDeleted) return BadRequest("Cargo process deleted process is unsuccess !");

            return Ok("Cargo process was deleted successfully !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProcessUpdateDto entityUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            bool wasUpdated = await processService.UpdateAsync(entityUpdateDto);
            if (!wasUpdated) return BadRequest("Cargo process updated process is unsuccess !");

            return Ok("Cargo process was updated successfully !");
        }
    }
}