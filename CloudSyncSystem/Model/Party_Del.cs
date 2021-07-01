using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CloudSyncSystem.Model
{
    class Party_Del
    {
        [BsonId]
        public int DelId { get; set; }
        [BsonElement("ts")]
        public int ts { get; set; }
    }

}
