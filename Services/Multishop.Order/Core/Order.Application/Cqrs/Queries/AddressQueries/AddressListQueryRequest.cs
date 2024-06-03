using MediatR;

namespace Order.Application.Cqrs.Queries.AddressQueries
{
    public class AddressListQueryRequest : IRequest<IEnumerable<AddressListQueryResponse>>
    {
    }
}