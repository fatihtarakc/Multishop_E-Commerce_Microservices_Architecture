using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}