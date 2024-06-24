using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Settings.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class OfferRepository : IOfferRepository
    {
        private readonly IMongoCollection<Offer> offerCollection;
        public OfferRepository(IDbSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var db = client.GetDatabase(dbSettings.DatabaseName);
            offerCollection = db.GetCollection<Offer>(dbSettings.OfferCollectionName);
        }

        public async Task AddAsync(Offer entity)
        {
            await offerCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string entityId)
        {
            await offerCollection.DeleteOneAsync(offer => offer.Id == entityId);
        }

        public async Task UpdateAsync(Offer entity)
        {
            await offerCollection.FindOneAndReplaceAsync(offer => offer.Id == entity.Id, entity);
        }

        public async Task<Offer> GetFirstOrDefaultAsync(Expression<Func<Offer, bool>> expression)
        {
            return await offerCollection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Offer>> GetAllAsync()
        {
            return await offerCollection.Find(offer => true).ToListAsync();
        }
    }
}