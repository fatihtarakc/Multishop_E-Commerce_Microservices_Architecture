using Cargo.Business.Services.Abstract;
using Cargo.Dto.CompanyDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet("Companies")]
        public async Task<IActionResult> Companies()
        {
            var companyListDtos = await companyService.GetAllAsync();
            return Ok(companyListDtos);
        }

        [HttpGet("GetBy/{entityId}")]
        public async Task<IActionResult> GetBy(Guid entityId)
        {
            var company = await companyService.GetFirstOrDefaultAsync(company => company.Id == entityId);
            if (company is null) return NotFound("Searching company was not found !");

            return Ok(company);
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CompanyAddDto entityAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            bool wasAdded = await companyService.AddAsync(entityAddDto);
            if (!wasAdded) return BadRequest("New company added process is unsuccess !");

            return Ok("New company was added successfully !");
        }

        [Authorize]
        [HttpDelete("Delete/{entityId}")]
        public async Task<IActionResult> Delete(Guid entityId)
        {
            bool wasDeleted = await companyService.DeleteAsync(entityId);
            if (!wasDeleted) return BadRequest("Company deleted process is unsuccess !");

            return Ok("Company was deleted successfully !");
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(CompanyUpdateDto entityUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            bool wasUpdated = await companyService.UpdateAsync(entityUpdateDto);
            if (!wasUpdated) return BadRequest("Company updated process is unsuccess !");

            return Ok("Company was updated successfully !");
        }
    }
}