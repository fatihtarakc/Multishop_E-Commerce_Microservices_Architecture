using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> productCollection;
        private readonly Options.MongodbDatabaseOptions mongodbDatabaseOptions;
        public ProductRepository(IOptions<Options.MongodbDatabaseOptions> mongodbDatabaseOptions)
        {
            this.mongodbDatabaseOptions = mongodbDatabaseOptions.Value;
            var client = new MongoClient(this.mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(this.mongodbDatabaseOptions.Database);
            productCollection = db.GetCollection<Product>(this.mongodbDatabaseOptions.ProductCollection);
        }

        public async Task AddAsync(Product entity) =>
            await productCollection.InsertOneAsync(entity);

        public async Task DeleteAsync(string entityId) =>
            await productCollection.DeleteOneAsync(product => product.Id == entityId);

        public async Task UpdateAsync(Product entity) =>
            await productCollection.FindOneAndReplaceAsync(product => product.Id == entity.Id, entity);

        public async Task<Product> GetFirstOrDefaultAsync(Expression<Func<Product, bool>> expression) =>
            await productCollection.Find(expression).FirstOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetAllWhereAsync(Expression<Func<Product, bool>> expression) =>
            await productCollection.Find(expression).ToListAsync();

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await productCollection.Find(product => true).ToListAsync();
    }
}