using MediatR;

namespace Order.Application.Cqrs.Commands.AddressCommands
{
    public class AddressDeleteCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}