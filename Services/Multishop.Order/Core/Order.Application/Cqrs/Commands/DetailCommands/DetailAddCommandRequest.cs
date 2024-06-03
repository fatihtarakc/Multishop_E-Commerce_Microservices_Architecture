using MediatR;

namespace Order.Application.Cqrs.Commands.DetailCommands
{
    public class DetailAddCommandRequest : IRequest<bool>
    {
        // Product entity has been located MongoDb database.
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }

        // Relations
        public Guid OrderId { get; set; }
    }
}