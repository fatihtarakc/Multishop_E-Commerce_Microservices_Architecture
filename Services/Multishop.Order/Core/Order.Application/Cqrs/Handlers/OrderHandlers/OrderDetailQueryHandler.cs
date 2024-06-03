using Mapster;
using MediatR;
using Order.Application.Cqrs.Queries.OrderQueries;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.OrderHandlers
{
    public class OrderDetailQueryHandler : IRequestHandler<OrderDetailQueryRequest, OrderDetailQueryResponse>
    {
        private readonly IOrderRepository orderRepository;
        public OrderDetailQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<OrderDetailQueryResponse> Handle(OrderDetailQueryRequest orderDetailQueryRequest, CancellationToken cancellationToken)
            => (await orderRepository.GetFirstOrDefaultAsync(order => order.Id == orderDetailQueryRequest.Id)).Adapt<OrderDetailQueryResponse>();
    }
}