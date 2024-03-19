using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BrentBaillieAPI.Models
{
    public class Info
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? city { get; set; }
        public string? province { get; set; }
        public string? country { get; set; }

    }
}
