using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Multishop.Catalog.Data.Entities
{
    public class Brand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}