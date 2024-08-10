namespace Multishop.Catalog.Options
{
    public class MongodbDatabaseOptions
    {
        public const string MongodbDatabase = "MongodbDatabase";

        public string AdvertisementCollection { get; set; }
        public string BrandCollection { get; set; }
        public string CategoryCollection { get; set; }
        public string ContactCollection { get; set; }
        public string DetailCollection { get; set; }
        public string ImageCollection { get; set; }
        public string OfferCollection { get; set; }
        public string ProductCollection { get; set; }
        public string ServiceCollection { get; set; }
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}