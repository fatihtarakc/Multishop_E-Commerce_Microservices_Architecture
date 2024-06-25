using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Multishop.Catalog.Data.Entities
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
    }
}