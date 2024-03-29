﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assets.API.Entities
{
    public class AssetsType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
