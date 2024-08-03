namespace Multishop.UI.Options
{
    public class RouteOptions
    {
        public const string Route = "Route";

        public string ApiGateway { get; set; }
        public string IdentityServer { get; set; }
        public string Catalog { get; set; }
        public string Discount { get; set; }
        public string Order { get; set; }
        public string Cargo { get; set; }
        public string Basket { get; set; }
        public string Comment { get; set; }
        public string Payment { get; set; }
        public string Image { get; set; }
    }
}