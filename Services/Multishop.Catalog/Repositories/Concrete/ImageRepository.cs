using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Options;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class ImageRepository : IImageRepository
    {
        private readonly IMongoCollection<Image> imageCollection;
        public ImageRepository(IMongodbDatabaseOptions mongodbDatabaseOptions)
        {
            var client = new MongoClient(mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(mongodbDatabaseOptions.DatabaseName);
            imageCollection = db.GetCollection<Image>(mongodbDatabaseOptions.ImageCollectionName);
        }

        public async Task AddAsync(Image entity)
        {
            await imageCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string entityId)
        {
            await imageCollection.DeleteOneAsync(image => image.Id == entityId);
        }

        public async Task UpdateAsync(Image entity)
        {
            await imageCollection.FindOneAndReplaceAsync(image => image.Id == entity.Id, entity);
        }

        public async Task<Image> GetFirstOrDefaultAsync(Expression<Func<Image, bool>> expression)
        {
            return await imageCollection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Image>> GetAllWhereAsync(Expression<Func<Image, bool>> expression)
        {
            return await imageCollection.Find(expression).ToListAsync();
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await imageCollection.Find(image => true).ToListAsync();
        }
    }
}