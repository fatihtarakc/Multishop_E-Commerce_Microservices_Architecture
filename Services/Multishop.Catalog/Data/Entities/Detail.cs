using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Multishop.Catalog.Data.Entities
{
    public class Detail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }

        // Relations
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}