using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tickets.Core.Entities
{
    public class LogEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Content { get; set; }       
        
        public string UserName { get; set; }
        
        public DateTime DateRegistration { get; set; }
        
        public string State { get; set; }
    }
}