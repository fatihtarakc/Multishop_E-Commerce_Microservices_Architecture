using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Options;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly IMongoCollection<Advertisement> advertisementCollection;
        public AdvertisementRepository(IMongodbDatabaseOptions mongodbDatabaseOptions)
        {
            var client = new MongoClient(mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(mongodbDatabaseOptions.DatabaseName);
            advertisementCollection = db.GetCollection<Advertisement>(mongodbDatabaseOptions.AdvertisementCollectionName);
        }

        public async Task AddAsync(Advertisement entity)
        {
            await advertisementCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string entityId)
        {
            await advertisementCollection.DeleteOneAsync(advertisement => advertisement.Id == entityId);
        }

        public async Task UpdateAsync(Advertisement entity)
        {
            await advertisementCollection.FindOneAndReplaceAsync(advertisement => advertisement.Id == entity.Id, entity);
        }

        public async Task<Advertisement> GetFirstOrDefaultAsync(Expression<Func<Advertisement, bool>> expression)
        {
            return await advertisementCollection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Advertisement>> GetAllAsync()
        {
            return await advertisementCollection.Find(advertisement => true).ToListAsync();
        }
    }
}