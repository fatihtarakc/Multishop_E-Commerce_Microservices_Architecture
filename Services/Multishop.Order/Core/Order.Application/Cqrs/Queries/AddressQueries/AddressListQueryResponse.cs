namespace Order.Application.Cqrs.Queries.AddressQueries
{
    public class AddressListQueryResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreationDate { get; set; }
    }
}