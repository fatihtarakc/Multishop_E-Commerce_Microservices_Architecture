using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Cqrs.Commands.DetailCommands;
using Order.Application.Cqrs.Queries.DetailQueries;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly IMediator mediator;
        public DetailController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details()
        {
            var detailListQueryResponses = await mediator.Send(new DetailListQueryRequest());
            if (detailListQueryResponses is null) return NotFound("Detail info has not been system yet !");

            return Ok(detailListQueryResponses);
        }

        [HttpGet("GetBy/{detailId}")]
        public async Task<IActionResult> GetBy(Guid detailId)
        {
            var detailDetailQueryResponse = await mediator.Send(new DetailDetailQueryRequest() { Id = detailId });
            if (detailDetailQueryResponse is null) return NotFound("Detail info was not found !");

            return Ok(detailDetailQueryResponse);
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(DetailAddCommandRequest detailAddCommandRequest)
        {
            bool response = await mediator.Send(detailAddCommandRequest);
            if (!response) return BadRequest("This detail info added process to system is unsuccess !");

            return Ok("This detail info was added successfully !");
        }

        [Authorize]
        [HttpDelete("Delete/{addressId}")]
        public async Task<IActionResult> Delete(Guid addressId)
        {
            bool response = await mediator.Send(new DetailDeleteCommandRequest() { Id = addressId });
            if (!response) return BadRequest("This detail info deleted process from system is unsuccess !");

            return Ok("This detail info was deleted successfully !");
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(DetailUpdateCommandRequest detailUpdateCommandRequest)
        {
            bool response = await mediator.Send(detailUpdateCommandRequest);
            if (!response) return BadRequest("This detail info updated process is unsuccess !");
            
            return Ok("This detail info was updated successfully !");
        }
    }
}