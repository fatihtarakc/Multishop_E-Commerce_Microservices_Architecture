namespace Multishop.Catalog.Settings.Abstract
{
    public interface IDbSettings
    {
        public string CategoryCollectionName { get; set; }
        public string DetailCollectionName { get; set; }
        public string ImageCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}