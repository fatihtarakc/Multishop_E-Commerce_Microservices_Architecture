using MediatR;

namespace Order.Application.Cqrs.Commands.AddressCommands
{
    public class AddressUpdateCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Info { get; set; }
    }
}