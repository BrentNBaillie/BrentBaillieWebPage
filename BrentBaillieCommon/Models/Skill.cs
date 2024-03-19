using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BrentBaillieAPI.Models
{
    public class Skill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string? category { get; set; }
        public string? name { get; set; }
    }
}
