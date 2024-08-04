namespace Multishop.Catalog.Options
{
    public class MongodbDatabaseOptions : IMongodbDatabaseOptions
    {
        public const string MongodbDatabase = "MongodbDatabase";

        public string AdvertisementCollectionName { get; set; }
        public string BrandCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string DetailCollectionName { get; set; }
        public string ImageCollectionName { get; set; }
        public string OfferCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ServiceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}