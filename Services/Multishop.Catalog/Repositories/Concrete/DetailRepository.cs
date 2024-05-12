using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Settings.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class DetailRepository : IDetailRepository
    {
        private readonly IMongoCollection<Detail> detailCollection;
        public DetailRepository(IDbSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var db = client.GetDatabase(dbSettings.DatabaseName);
            detailCollection = db.GetCollection<Detail>(dbSettings.DetailCollectionName);
        }

        public async Task AddAsync(Detail entity)
        {
            await detailCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string entityId)
        {
            await detailCollection.DeleteOneAsync(detail => detail.Id == entityId);
        }

        public async Task UpdateAsync(Detail entity)
        {
            await detailCollection.FindOneAndReplaceAsync(detail => detail.Id == entity.Id, entity);
        }

        public async Task<Detail> GetFirstOrDefaultAsync(Expression<Func<Detail, bool>> expression)
        {
            return await detailCollection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Detail>> GetAllAsync()
        {
            return await detailCollection.Find(detail => true).ToListAsync();
        }
    }
}