using Mapster;
using MediatR;
using Order.Application.Cqrs.Commands.OrderCommands;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.OrderHandlers
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommandRequest, bool>
    {
        private readonly IOrderRepository orderRepository;
        public OrderAddCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<bool> Handle(OrderAddCommandRequest orderAddCommandRequest, CancellationToken cancellationToken)
            => await orderRepository.AddAsync(orderAddCommandRequest.Adapt<Order.Domain.Entities.Concrete.Order>());
    }
}