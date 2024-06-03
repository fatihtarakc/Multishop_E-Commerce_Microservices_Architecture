using MediatR;

namespace Order.Application.Cqrs.Commands.OrderCommands
{
    public class OrderDeleteCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}