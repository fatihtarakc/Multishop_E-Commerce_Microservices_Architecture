using MediatR;

namespace Order.Application.Cqrs.Queries.AddressQueries
{
    public class AddressDetailQueryRequest : IRequest<AddressDetailQueryResponse>
    {
        public Guid Id { get; set; }
    }
}