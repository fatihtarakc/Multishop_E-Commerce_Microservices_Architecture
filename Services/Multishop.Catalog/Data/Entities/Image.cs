using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Multishop.Catalog.Data.Entities
{
    public class Image
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Url { get; set; }

        // Relations
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}