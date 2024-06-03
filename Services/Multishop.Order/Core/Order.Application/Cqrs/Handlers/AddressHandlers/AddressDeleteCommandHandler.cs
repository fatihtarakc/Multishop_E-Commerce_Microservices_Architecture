using MediatR;
using Order.Application.Cqrs.Commands.AddressCommands;
using Order.Application.Repositories.Abstract;

namespace Order.Application.Cqrs.Handlers.AddressHandlers
{
    public class AddressDeleteCommandHandler : IRequestHandler<AddressDeleteCommandRequest, bool>
    {
        private readonly IAddressRepository addressRepository;
        public AddressDeleteCommandHandler(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task<bool> Handle(AddressDeleteCommandRequest addressDeleteCommandRequest, CancellationToken cancellationToken)
            => await addressRepository.DeleteAsync(addressDeleteCommandRequest.Id);
    }
}