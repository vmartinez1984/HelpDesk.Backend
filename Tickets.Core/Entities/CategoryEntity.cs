using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tickets.Core.Entities
{
    public class CategoryEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Log { get; set; }

        public bool IsActive { get; set; }
    }
}