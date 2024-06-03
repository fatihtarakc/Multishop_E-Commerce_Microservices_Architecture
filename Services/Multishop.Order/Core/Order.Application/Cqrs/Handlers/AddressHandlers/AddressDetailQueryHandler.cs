using Mapster;
using MediatR;
using Order.Application.Cqrs.Queries.AddressQueries;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.AddressHandlers
{
    public class AddressDetailQueryHandler : IRequestHandler<AddressDetailQueryRequest, AddressDetailQueryResponse>
    {
        private readonly IAddressRepository addressRepository;
        public AddressDetailQueryHandler(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task<AddressDetailQueryResponse> Handle(AddressDetailQueryRequest addressDetailQueryRequest, CancellationToken cancellationToken)
            => (await addressRepository.GetFirstOrDefaultAsync(address => address.Id == addressDetailQueryRequest.Id)).Adapt<AddressDetailQueryResponse>();
    }
}