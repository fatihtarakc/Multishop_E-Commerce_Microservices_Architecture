using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Multishop.Catalog.Data.Entities
{
    public class Product
    {
        public Product()
        {
            Images = new List<Image>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        // Relations
        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
        public string DetailId { get; set; }
        [BsonIgnore]
        public Detail Detail { get; set; }
        [BsonIgnore]
        public IEnumerable<Image> Images { get; set; }
    }
}