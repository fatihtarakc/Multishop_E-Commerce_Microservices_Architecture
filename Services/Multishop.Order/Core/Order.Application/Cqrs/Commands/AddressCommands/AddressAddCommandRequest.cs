using MediatR;

namespace Order.Application.Cqrs.Commands.AddressCommands
{
    public class AddressAddCommandRequest : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Info { get; set; }
    }
}