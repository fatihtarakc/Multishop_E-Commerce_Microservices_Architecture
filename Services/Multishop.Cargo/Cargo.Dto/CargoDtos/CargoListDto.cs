namespace Cargo.Dto.CargoDtos
{
    public class CargoListDto
    {
        public Guid Id { get; set; }
        public string TrackingNo { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime CreationDate { get; set; }

        // Relations
        public Guid CompanyId { get; set; }
    }
}