using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Options;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> categoryCollection;
        public CategoryRepository(IMongodbDatabaseOptions mongodbDatabaseOptions)
        {
            var client = new MongoClient(mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(mongodbDatabaseOptions.DatabaseName);
            categoryCollection = db.GetCollection<Category>(mongodbDatabaseOptions.CategoryCollectionName);
        }

        public async Task AddAsync(Category entity)
        {
            await categoryCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string entityId)
        {
            await categoryCollection.DeleteOneAsync(category => category.Id == entityId);
        }

        public async Task UpdateAsync(Category entity)
        {
            await categoryCollection.FindOneAndReplaceAsync(category => category.Id == entity.Id, entity);
        }

        public async Task<Category> GetFirstOrDefaultAsync(Expression<Func<Category, bool>> expression)
        {
            return await categoryCollection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await categoryCollection.Find(category => true).ToListAsync();
        }
    }
}