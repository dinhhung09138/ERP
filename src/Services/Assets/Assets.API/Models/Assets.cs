using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assets.API.Models
{
    public class Assets
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Code")]
        public string Code { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public DateTime DateBy { get; set; }

        public DateTime? WantityDate { get; set; }
    }
}
