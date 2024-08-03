namespace Multishop.UI.Options
{
    public class ClientOptions
    {
        public const string Client = "Client";
        public Client Visitor { get; set; }
        public Client Manager { get; set; }
        public Client Admin { get; set; }
    }

    public class Client
    {
        public string Id { get; set; }
        public string Secret { get; set; }
    }
}
