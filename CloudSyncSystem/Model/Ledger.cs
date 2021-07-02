using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CloudSyncSystem.Model
{
    class Ledger
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public int Id { get; set; }
        [BsonElement("PartyId")]
        public int PartyId { get; set; }
        [BsonElement("VocNo")]
        public int? VocNo { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }
        [BsonElement("TType")]
        public string TType { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Debit")]
        public Int64? Debit { get; set; }
        [BsonElement("Credit")]
        public Int64? Credit { get; set; }
        [BsonElement("ts")]
        public int ts { get; set; }
    }

    class UpdatedLedger
    {
        [BsonElement("Id")]
        public int Id { get; set; }
        [BsonElement("PartyID")]
        public int PartyID { get; set; }
        [BsonElement("VocNo")]
        public int? VocNo { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }
        [BsonElement("TType")]
        public string TType { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Debit")]
        public Int64? Debit { get; set; }
        [BsonElement("Credit")]
        public Int64? Credit { get; set; }
        [BsonElement("ts")]
        public int ts { get; set; }
    }
}
