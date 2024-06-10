namespace Cargo.Dto.CargoDtos
{
    public class CargoUpdateDto
    {
        public Guid Id { get; set; }
        public string TrackingNo { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }

        // Relations
        public Guid CompanyId { get; set; }
    }
}