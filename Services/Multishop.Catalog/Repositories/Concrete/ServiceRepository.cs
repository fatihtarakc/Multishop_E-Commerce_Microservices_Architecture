using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IMongoCollection<Service> serviceCollection;
        private readonly Options.MongodbDatabaseOptions mongodbDatabaseOptions;
        public ServiceRepository(IOptions<Options.MongodbDatabaseOptions> mongodbDatabaseOptions)
        {
            this.mongodbDatabaseOptions = mongodbDatabaseOptions.Value;
            var client = new MongoClient(this.mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(this.mongodbDatabaseOptions.Database);
            serviceCollection = db.GetCollection<Service>(this.mongodbDatabaseOptions.ServiceCollection);
        }

        public async Task AddAsync(Service entity) =>
            await serviceCollection.InsertOneAsync(entity);

        public async Task DeleteAsync(string entityId) =>
            await serviceCollection.DeleteOneAsync(service => service.Id == entityId);

        public async Task UpdateAsync(Service entity) =>
            await serviceCollection.FindOneAndReplaceAsync(service => service.Id == entity.Id, entity);

        public async Task<Service> GetFirstOrDefaultAsync(Expression<Func<Service, bool>> expression) =>
            await serviceCollection.Find(expression).FirstOrDefaultAsync();

        public async Task<IEnumerable<Service>> GetAllAsync() =>
            await serviceCollection.Find(service => true).ToListAsync();
    }
}