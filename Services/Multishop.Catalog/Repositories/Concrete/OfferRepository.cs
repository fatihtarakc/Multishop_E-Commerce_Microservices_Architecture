using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class OfferRepository : IOfferRepository
    {
        private readonly IMongoCollection<Offer> offerCollection;
        private readonly Options.MongodbDatabaseOptions mongodbDatabaseOptions;
        public OfferRepository(IOptions<Options.MongodbDatabaseOptions> mongodbDatabaseOptions)
        {
            this.mongodbDatabaseOptions = mongodbDatabaseOptions.Value;
            var client = new MongoClient(this.mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(this.mongodbDatabaseOptions.Database);
            offerCollection = db.GetCollection<Offer>(this.mongodbDatabaseOptions.OfferCollection);
        }

        public async Task AddAsync(Offer entity) =>
            await offerCollection.InsertOneAsync(entity);

        public async Task DeleteAsync(string entityId) =>
            await offerCollection.DeleteOneAsync(offer => offer.Id == entityId);

        public async Task UpdateAsync(Offer entity) =>
            await offerCollection.FindOneAndReplaceAsync(offer => offer.Id == entity.Id, entity);

        public async Task<Offer> GetFirstOrDefaultAsync(Expression<Func<Offer, bool>> expression) =>
            await offerCollection.Find(expression).FirstOrDefaultAsync();

        public async Task<IEnumerable<Offer>> GetAllAsync() =>
            await offerCollection.Find(offer => true).ToListAsync();
    }
}