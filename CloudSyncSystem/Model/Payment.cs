using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CloudSyncSystem.Model
{
    class Payment
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public int Id { get; set; }
        [BsonElement("PartyID")]
        public int PartyID { get; set; }
        [BsonElement("VocNo")]
        public int VocNo { get; set; }
        [BsonElement("SrNo")]
        public int SrNo { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }
        [BsonElement("TType")]
        public int TType { get; set; }
        [BsonElement("CheckID")]
        public int CheckID { get; set; }
        [BsonElement("ChqNo")]
        public string ChqNo { get; set; }
        [BsonElement("Bank")]
        public string Bank { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Credit")]
        public Int64? Credit { get; set; }
        [BsonElement("IssueFrom")]
        public int IssueFrom { get; set; }
        [BsonElement("ActualPartyID")]
        public int ActualPartyID { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        [BsonElement("Remarks")]
        public string Remarks { get; set; }
        [BsonElement("ts")]
        public int ts { get; set; }
    }
}
