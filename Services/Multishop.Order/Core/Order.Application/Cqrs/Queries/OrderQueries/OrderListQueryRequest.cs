using MediatR;

namespace Order.Application.Cqrs.Queries.OrderQueries
{
    public class OrderListQueryRequest : IRequest<IEnumerable<OrderListQueryResponse>>
    {
    }
}