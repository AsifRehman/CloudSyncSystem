using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CloudSyncSystem.Model
{
    class Party
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public int Id { get; set; }
        [BsonElement("PartyName")]
        public string PartyName { get; set; }
        [BsonElement("PartyTypeId")]
        public int PartyTypeId { get; set; }
        [BsonElement("Debit")]
        public int? Debit { get; set; }
        [BsonElement("Credit")]
        public int? Credit { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }
        [BsonElement("Mobile1")]
        public string Mobile1 { get; set; }
        [BsonElement("Mobile2")]
        public string Mobile2 { get; set; }
        [BsonElement("ts")]
        public int ts { get; set; }
    }

}
