using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Cqrs.Commands.OrderCommands;
using Order.Application.Cqrs.Queries.OrderQueries;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("Orders")]
        public async Task<IActionResult> Orders()
        {
            var orderListQueryResponses = await mediator.Send(new OrderListQueryRequest());
            if (orderListQueryResponses is null) return NotFound("Order info has not been system yet !");

            return Ok(orderListQueryResponses);
        }

        [HttpGet("GetBy/{orderId}")]
        public async Task<IActionResult> GetBy(Guid orderId)
        {
            var orderDetailQueryResponse = await mediator.Send(new OrderDetailQueryRequest() { Id = orderId });
            if (orderDetailQueryResponse is null) return NotFound("Order info was not found !");

            return Ok(orderDetailQueryResponse);
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(OrderAddCommandRequest orderAddCommandRequest)
        {
            bool response = await mediator.Send(orderAddCommandRequest);
            if (!response) return BadRequest("This order info added process to system is unsuccess !");

            return Ok("This order info was added successfully !");
        }

        [Authorize]
        [HttpDelete("Delete/{orderId}")]
        public async Task<IActionResult> Delete(Guid orderId)
        {
            bool response = await mediator.Send(new OrderDeleteCommandRequest() { Id = orderId });
            if (!response) return BadRequest("This order info deleted process from system is unsuccess !");

            return Ok("This order info was deleted successfully !");
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(OrderUpdateCommandRequest orderUpdateCommandRequest)
        {
            bool response = await mediator.Send(orderUpdateCommandRequest);
            if (!response) return BadRequest("This order info updated process is unsuccess !");

            return Ok("This order info was updated successfully !");
        }
    }
}