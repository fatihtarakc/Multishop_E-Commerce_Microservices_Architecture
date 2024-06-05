using Mapster;
using MediatR;
using Order.Application.Cqrs.Commands.AddressCommands;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.AddressHandlers
{
    public class AddressUpdateCommandHandler : IRequestHandler<AddressUpdateCommandRequest, bool>
    {
        private readonly IAddressRepository addressRepository;
        public AddressUpdateCommandHandler(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task<bool> Handle(AddressUpdateCommandRequest addressUpdateCommandRequest, CancellationToken cancellationToken)
        {
            var address = await addressRepository.GetFirstOrDefaultAsync(address => address.Id == addressUpdateCommandRequest.Id);
            if (address is null) return false;

            return await addressRepository.UpdateAsync(addressUpdateCommandRequest.Adapt(address));
        }
    }
}