using MediatR;

namespace Order.Application.Cqrs.Queries.DetailQueries
{
    public class DetailDetailQueryRequest : IRequest<DetailDetailQueryResponse>
    {
        public Guid Id { get; set; }
    }
}