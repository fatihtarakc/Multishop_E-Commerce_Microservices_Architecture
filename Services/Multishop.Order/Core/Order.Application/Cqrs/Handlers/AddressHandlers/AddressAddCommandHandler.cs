using Mapster;
using MediatR;
using Order.Application.Cqrs.Commands.AddressCommands;
using Order.Application.Repositories.Abstract;
using Order.Domain.Entities.Concrete;

namespace Order.Application.Cqrs.Handlers.AddressHandlers
{
    public class AddressAddCommandHandler : IRequestHandler<AddressAddCommandRequest, bool>
    {
        private readonly IAddressRepository addressRepository;
        public AddressAddCommandHandler(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task<bool> Handle(AddressAddCommandRequest addressAddCommandRequest, CancellationToken cancellationToken)
        {
            return await addressRepository.AddAsync(addressAddCommandRequest.Adapt<Address>());
        }
    }
}