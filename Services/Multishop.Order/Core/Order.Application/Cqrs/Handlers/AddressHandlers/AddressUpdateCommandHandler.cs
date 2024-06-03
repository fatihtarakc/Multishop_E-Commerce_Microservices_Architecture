using Mapster;
using MediatR;
using Order.Application.Cqrs.Commands.AddressCommands;
using Order.Application.Repositories.Abstract;
using Order.Domain.Entities.Concrete;

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
            => await addressRepository.UpdateAsync(addressUpdateCommandRequest.Adapt<Address>());
    }
}