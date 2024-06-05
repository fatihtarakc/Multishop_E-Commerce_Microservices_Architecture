using MediatR;

namespace Order.Application.Cqrs.Commands.OrderCommands
{
    public class OrderAddCommandRequest : IRequest<bool>
    {
        public Guid UserId { get; set; }
    }
}