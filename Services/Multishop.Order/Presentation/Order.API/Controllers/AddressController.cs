using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Cqrs.Commands.AddressCommands;
using Order.Application.Cqrs.Queries.AddressQueries;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator mediator;
        public AddressController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("Addresses")]
        public async Task<IActionResult> Addresses()
        {
            var addressListQueryResponses = await mediator.Send(new AddressListQueryRequest());
            if (addressListQueryResponses is null) return NotFound("Address info has not been system yet !");

            return Ok(addressListQueryResponses);
        }

        [HttpGet("GetBy/{addressId}")]
        public async Task<IActionResult> GetBy(Guid addressId)
        {
            var addressDetailQueryResponse = await mediator.Send(new AddressDetailQueryRequest() { Id = addressId });
            if (addressDetailQueryResponse is null) return NotFound("Address info was not found !");

            return Ok(addressDetailQueryResponse);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddressAddCommandRequest addressAddCommandRequest)
        {
            bool response = await mediator.Send(addressAddCommandRequest);
            if (!response) return BadRequest("This detail info added process to system is unsuccess !");

            return Ok("This address info was added successfully !");
        }

        [HttpDelete("Delete/{addressId}")]
        public async Task<IActionResult> Delete(Guid addressId)
        {
            bool response = await mediator.Send(new AddressDeleteCommandRequest() { Id = addressId });
            if (!response) return BadRequest("This detail info deleted process from system is unsuccess !");
            
            return Ok("This address info was deleted successfully !");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(AddressUpdateCommandRequest addressUpdateCommandRequest)
        {
            bool response = await mediator.Send(addressUpdateCommandRequest);
            if (!response) return BadRequest("This address info updated process is unsuccess !");
            
            return Ok("This address info was updated successfully !");
        }
    }
}