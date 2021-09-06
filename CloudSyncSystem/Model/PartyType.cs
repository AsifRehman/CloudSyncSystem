using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CloudSyncSystem.Model
{
    class PartyType
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public int Id { get; set; }
        [BsonElement("PartyTypeName")]
        public string PartyTypeName { get; set; }
        [BsonElement("PartyGroup")]
        public string PartyGroup{ get; set; }
        [BsonElement("ts")]
        public int ts { get; set; }
    }

}
