using Cargo.Business.Services.Abstract;
using Cargo.Dto.CargoDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService cargoService;
        public CargoController(ICargoService cargoService)
        {
            this.cargoService = cargoService;
        }

        [HttpGet("Cargos")]
        public async Task<IActionResult> Cargos()
        {
            var cargoListDtos = await cargoService.GetAllAsync();
            return Ok(cargoListDtos);
        }

        [HttpGet("GetBy/{entityId}")]
        public async Task<IActionResult> GetBy(Guid entityId)
        {
            var cargo = await cargoService.GetFirstOrDefaultAsync(cargo => cargo.Id == entityId);
            if (cargo is null) return NotFound("Searching cargo was not found !");

            return Ok(cargo);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CargoAddDto entityAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            bool wasAdded = await cargoService.AddAsync(entityAddDto);
            if (!wasAdded) return BadRequest("New cargo information added process is unsuccess !");

            return Ok("New cargo information was added successfully !");
        }

        [HttpDelete("Delete/{entityId}")]
        public async Task<IActionResult> Delete(Guid entityId)
        {
            bool wasDeleted = await cargoService.DeleteAsync(entityId);
            if (!wasDeleted) return BadRequest("Cargo information deleted process is unsuccess !");

            return Ok("Cargo information was deleted successfully !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CargoUpdateDto entityUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            bool wasUpdated = await cargoService.UpdateAsync(entityUpdateDto);
            if (!wasUpdated) return BadRequest("Cargo information updated process is unsuccess !");

            return Ok("Cargo information was updated successfully !");
        }
    }
}