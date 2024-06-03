using Mapster;
using MediatR;
using Order.Application.Cqrs.Queries.OrderQueries;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.OrderHandlers
{
    public class OrderListQueryHandler : IRequestHandler<OrderListQueryRequest, IEnumerable<OrderListQueryResponse>>
    {
        private readonly IOrderRepository orderRepository;
        public OrderListQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderListQueryResponse>> Handle(OrderListQueryRequest orderListQueryRequest, CancellationToken cancellationToken)
            => (await orderRepository.GetAllAsync()).Adapt<IEnumerable<OrderListQueryResponse>>();
    }
}