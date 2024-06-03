using MediatR;

namespace Order.Application.Cqrs.Queries.OrderQueries
{
    public class OrderDetailQueryRequest : IRequest<OrderDetailQueryResponse>
    {
        public Guid Id { get; set; }
    }
}