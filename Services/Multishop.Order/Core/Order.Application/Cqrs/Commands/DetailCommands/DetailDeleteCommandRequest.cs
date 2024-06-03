using MediatR;

namespace Order.Application.Cqrs.Commands.DetailCommands
{
    public class DetailDeleteCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}