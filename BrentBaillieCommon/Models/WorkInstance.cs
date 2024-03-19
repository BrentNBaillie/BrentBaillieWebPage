using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BrentBaillieAPI.Models
{
    public class WorkInstance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string? type { get; set; }
        public string? company { get; set; }
        public string? jobTitle { get; set; }
        public string? city { get; set; }
        public string? startYear { get; set; }
        public string? endYear { get; set; }
        public string? description { get; set; }
    }
}
