using MediatR;
using Order.Application.Cqrs.Commands.OrderCommands;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.OrderHandlers
{
    public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommandRequest, bool>
    {
        private readonly IOrderRepository orderRepository;
        public OrderDeleteCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<bool> Handle(OrderDeleteCommandRequest orderDeleteCommandRequest, CancellationToken cancellationToken)
            => await orderRepository.DeleteAsync(orderDeleteCommandRequest.Id);
    }
}