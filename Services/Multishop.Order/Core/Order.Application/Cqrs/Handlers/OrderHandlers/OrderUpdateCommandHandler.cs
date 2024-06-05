using Mapster;
using MediatR;
using Order.Application.Cqrs.Commands.OrderCommands;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.OrderHandlers
{
    public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommandRequest, bool>
    {
        private readonly IOrderRepository orderRepository;
        public OrderUpdateCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<bool> Handle(OrderUpdateCommandRequest orderUpdateCommandRequest, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetFirstOrDefaultAsync(order => order.Id == orderUpdateCommandRequest.Id);
            if (order is null) return false;

            return await orderRepository.UpdateAsync(orderUpdateCommandRequest.Adapt(order));
        }
    }
}