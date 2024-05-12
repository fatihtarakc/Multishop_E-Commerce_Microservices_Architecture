using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Settings.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> categoryCollection;
        public CategoryRepository(IDbSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var db = client.GetDatabase(dbSettings.DatabaseName);
            categoryCollection = db.GetCollection<Category>(dbSettings.CategoryCollectionName);
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