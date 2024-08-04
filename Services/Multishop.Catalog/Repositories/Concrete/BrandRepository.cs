using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Options;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IMongoCollection<Brand> brandCollection;
        public BrandRepository(IMongodbDatabaseOptions mongodbDatabaseOptions)
        {
            var client = new MongoClient(mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(mongodbDatabaseOptions.DatabaseName);
            brandCollection = db.GetCollection<Brand>(mongodbDatabaseOptions.BrandCollectionName);
        }

        public async Task AddAsync(Brand entity)
        {
            await brandCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string entityId)
        {
            await brandCollection.DeleteOneAsync(brand => brand.Id == entityId);
        }

        public async Task UpdateAsync(Brand entity)
        {
            await brandCollection.FindOneAndReplaceAsync(brand => brand.Id == entity.Id, entity);
        }

        public async Task<Brand> GetFirstOrDefaultAsync(Expression<Func<Brand, bool>> expression)
        {
            return await brandCollection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await brandCollection.Find(brand => true).ToListAsync();
        }
    }
}