using Mapster;
using MediatR;
using Order.Application.Cqrs.Queries.AddressQueries;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.AddressHandlers
{
    public class AddressListQueryHandler : IRequestHandler<AddressListQueryRequest, IEnumerable<AddressListQueryResponse>>
    {
        private readonly IAddressRepository addressRepository;
        public AddressListQueryHandler(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task<IEnumerable<AddressListQueryResponse>> Handle(AddressListQueryRequest addressListQueryRequest, CancellationToken cancellationToken)
            => (await addressRepository.GetAllAsync()).Adapt<IEnumerable<AddressListQueryResponse>>();
    }
}