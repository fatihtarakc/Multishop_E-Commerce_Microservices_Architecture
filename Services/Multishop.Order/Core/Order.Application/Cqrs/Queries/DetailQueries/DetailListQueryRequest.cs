using MediatR;

namespace Order.Application.Cqrs.Queries.DetailQueries
{
    public class DetailListQueryRequest : IRequest<IEnumerable<DetailListQueryResponse>>
    {
    }
}