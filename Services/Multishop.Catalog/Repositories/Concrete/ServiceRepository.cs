using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Options;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IMongoCollection<Service> serviceCollection;
        public ServiceRepository(IMongodbDatabaseOptions mongodbDatabaseOptions)
        {
            var client = new MongoClient(mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(mongodbDatabaseOptions.DatabaseName);
            serviceCollection = db.GetCollection<Service>(mongodbDatabaseOptions.ServiceCollectionName);
        }

        public async Task AddAsync(Service entity)
        {
            await serviceCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string entityId)
        {
            await serviceCollection.DeleteOneAsync(service => service.Id == entityId);
        }

        public async Task UpdateAsync(Service entity)
        {
            await serviceCollection.FindOneAndReplaceAsync(service => service.Id == entity.Id, entity);
        }

        public async Task<Service> GetFirstOrDefaultAsync(Expression<Func<Service, bool>> expression)
        {
            return await serviceCollection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await serviceCollection.Find(service => true).ToListAsync();
        }
    }
}