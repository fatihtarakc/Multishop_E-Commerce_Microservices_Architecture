using MediatR;

namespace Order.Application.Cqrs.Commands.OrderCommands
{
    public class OrderUpdateCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}