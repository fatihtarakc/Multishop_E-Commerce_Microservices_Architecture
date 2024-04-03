using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Data.Entities
{
    public class Category
    {
        public Category() 
        {
            Products = new List<Product>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

        // Relations
        [BsonIgnore]
        public IEnumerable<Product> Products { get; set; }
    }
}