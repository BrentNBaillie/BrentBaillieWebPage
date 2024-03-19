using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BrentBaillieAPI.Models
{
    public class Education
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string? schoolName { get; set; }
        public string? location { get; set; }
        public string? program { get; set; }
        public string? startYear { get; set; }
        public string? gradYear { get; set; }
    }
}
