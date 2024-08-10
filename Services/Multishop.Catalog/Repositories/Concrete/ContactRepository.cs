using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Multishop.Catalog.Data.Entities;
using Multishop.Catalog.Repositories.Abstract;
using System.Linq.Expressions;

namespace Multishop.Catalog.Repositories.Concrete
{
    public class ContactRepository : IContactRepository
    {
        private readonly IMongoCollection<Contact> contactCollection;
        private readonly Options.MongodbDatabaseOptions mongodbDatabaseOptions;
        public ContactRepository(IOptions<Options.MongodbDatabaseOptions> mongodbDatabaseOptions)
        {
            this.mongodbDatabaseOptions = mongodbDatabaseOptions.Value;
            var client = new MongoClient(this.mongodbDatabaseOptions.ConnectionString);
            var db = client.GetDatabase(this.mongodbDatabaseOptions.Database);
            contactCollection = db.GetCollection<Contact>(this.mongodbDatabaseOptions.ContactCollection);
        }

        public async Task AddAsync(Contact entity)
        {
            entity.SendDate = DateTime.Now;
            await contactCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string entityId) =>
            await contactCollection.DeleteOneAsync(contact => contact.Id == entityId);

        public async Task UpdateAsync(Contact entity) =>
            await contactCollection.FindOneAndReplaceAsync(contact => contact.Id == entity.Id, entity);

        public async Task<Contact> GetFirstOrDefaultAsync(Expression<Func<Contact, bool>> expression) =>
            await contactCollection.Find(expression).FirstOrDefaultAsync();

        public async Task<IEnumerable<Contact>> GetAllWhereAsync(Expression<Func<Contact, bool>> expression) =>
            await contactCollection.Find(expression).ToListAsync();

        public async Task<IEnumerable<Contact>> GetAllAsync() =>
            await contactCollection.Find(contact => true).ToListAsync();
    }
}