using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly IMongoCollection<Advertisement> advertisementCollection;
        private readonly Options.MongodbDatabaseOptions mongodbDatabaseOptions;
        public AdvertisementRepository(IOptions<Options.MongodbDatabaseOptions> mongodbDatabaseOptions)
        {
            this.mongodbDatabaseOptions = mongodbDatabaseOptions.Value;
            var client = new MongoClient(this.mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(this.mongodbDatabaseOptions.Database);
            advertisementCollection = db.GetCollection<Advertisement>(this.mongodbDatabaseOptions.AdvertisementCollection);
        }

        public async Task AddAsync(Advertisement entity) =>
            await advertisementCollection.InsertOneAsync(entity);

        public async Task DeleteAsync(string entityId) =>
            await advertisementCollection.DeleteOneAsync(advertisement => advertisement.Id == entityId);

        public async Task UpdateAsync(Advertisement entity) =>
            await advertisementCollection.FindOneAndReplaceAsync(advertisement => advertisement.Id == entity.Id, entity);

        public async Task<Advertisement> GetFirstOrDefaultAsync(Expression<Func<Advertisement, bool>> expression) =>
            await advertisementCollection.Find(expression).FirstOrDefaultAsync();

        public async Task<IEnumerable<Advertisement>> GetAllAsync() =>
            await advertisementCollection.Find(advertisement => true).ToListAsync();
    }
}