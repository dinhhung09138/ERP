using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assets.API.Entities
{
    public class Asset
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

        public bool Deleted { get; set; }

        public AssetsType AssetsType { get; set; }
    }
}
