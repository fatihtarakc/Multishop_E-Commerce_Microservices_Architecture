﻿using Multishop.Catalog.Settings.Abstract;

namespace Multishop.Catalog.Settings.Concrete
{
    public class DbSettings : IDbSettings
    {
        public string AdvertisementCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string DetailCollectionName { get; set; }
        public string ImageCollectionName { get; set; }
        public string OfferCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}