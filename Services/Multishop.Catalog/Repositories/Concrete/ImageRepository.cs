using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using Multishop.Catalog.Settings.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class ImageRepository : IImageRepository
    {
        private readonly IMongoCollection<Image> imageCollection;
        public ImageRepository(IDbSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var db = client.GetDatabase(dbSettings.DatabaseName);
            imageCollection = db.GetCollection<Image>(dbSettings.ImageCollectionName);
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

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await imageCollection.Find(image => true).ToListAsync();
        }
    }
}