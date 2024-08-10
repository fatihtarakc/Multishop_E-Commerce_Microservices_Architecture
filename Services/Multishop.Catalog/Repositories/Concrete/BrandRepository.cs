using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IMongoCollection<Brand> brandCollection;
        private readonly Options.MongodbDatabaseOptions mongodbDatabaseOptions;
        public BrandRepository(IOptions<Options.MongodbDatabaseOptions> mongodbDatabaseOptions)
        {
            this.mongodbDatabaseOptions = mongodbDatabaseOptions.Value;
            var client = new MongoClient(this.mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(this.mongodbDatabaseOptions.Database);
            brandCollection = db.GetCollection<Brand>(this.mongodbDatabaseOptions.BrandCollection);
        }

        public async Task AddAsync(Brand entity) =>
            await brandCollection.InsertOneAsync(entity);

        public async Task DeleteAsync(string entityId) =>
            await brandCollection.DeleteOneAsync(brand => brand.Id == entityId);

        public async Task UpdateAsync(Brand entity) =>
            await brandCollection.FindOneAndReplaceAsync(brand => brand.Id == entity.Id, entity);

        public async Task<Brand> GetFirstOrDefaultAsync(Expression<Func<Brand, bool>> expression) =>
            await brandCollection.Find(expression).FirstOrDefaultAsync();

        public async Task<IEnumerable<Brand>> GetAllAsync() =>
            await brandCollection.Find(brand => true).ToListAsync();
    }
}