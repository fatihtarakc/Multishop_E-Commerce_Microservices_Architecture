using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> categoryCollection;
        private readonly Options.MongodbDatabaseOptions mongodbDatabaseOptions;
        public CategoryRepository(IOptions<Options.MongodbDatabaseOptions> mongodbDatabaseOptions)
        {
            this.mongodbDatabaseOptions = mongodbDatabaseOptions.Value;
            var client = new MongoClient(this.mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(this.mongodbDatabaseOptions.Database);
            categoryCollection = db.GetCollection<Category>(this.mongodbDatabaseOptions.CategoryCollection);
        }

        public async Task AddAsync(Category entity) =>
            await categoryCollection.InsertOneAsync(entity);

        public async Task DeleteAsync(string entityId) =>
            await categoryCollection.DeleteOneAsync(category => category.Id == entityId);

        public async Task UpdateAsync(Category entity) =>
            await categoryCollection.FindOneAndReplaceAsync(category => category.Id == entity.Id, entity);

        public async Task<Category> GetFirstOrDefaultAsync(Expression<Func<Category, bool>> expression) =>
            await categoryCollection.Find(expression).FirstOrDefaultAsync();

        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await categoryCollection.Find(category => true).ToListAsync();
    }
}