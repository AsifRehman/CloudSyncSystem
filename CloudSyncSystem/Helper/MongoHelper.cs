using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace CloudSyncSystem
{
    public class MongoHelper
    {
        //private string conStr = "mongodb://asif:cosoft@cluster0-shard-00-00.k6lme.mongodb.net:27017,cluster0-shard-00-01.k6lme.mongodb.net:27017,cluster0-shard-00-02.k6lme.mongodb.net:27017/myFirstDatabase?ssl=true&replicaSet=atlas-9yuzik-shard-0&authSource=admin&retryWrites=true&w=majority";
        private string conStr = ConfigurationManager.AppSettings["MongoCon"].Replace("mongoPass","mongoPass^321~").Replace("mongoUser", ConfigurationManager.AppSettings["MongoUser"]);

        private IMongoDatabase db;
        public MongoHelper(string database)
        {
            var client = new MongoClient(conStr);
            db = client.GetDatabase(database);
        }

        public async Task InsertRecord<T>(string table, T record)
        {
            var col = db.GetCollection<T>(table);
            await col .InsertOneAsync(record);
        }

        public List<T> ReadRecords<T>(string table, T record)
        {
            var col = db.GetCollection<T>(table);
            return col.Find(new BsonDocument()).ToList();
        }

        public async Task<string> MaxTs(string table)
        {
                    var col = db.GetCollection<BsonDocument>(table);
                    var result = await col.Find(new BsonDocument()).SortByDescending(m => m["ts"]).Limit(1).FirstOrDefaultAsync();
                    if (result == null)
                        return "0";
                    else
                        return result.GetValue("ts").ToString();
        }
        public async Task UpsertRecord<T>(string table, int id, T record)
        {
            var col = db.GetCollection<T>(table);
            await col.ReplaceOneAsync(new BsonDocument("_id", id), record, new ReplaceOptions { IsUpsert = true });
        }
        public async Task DeleteRecord<T>(string table, int id)
        {
            var col = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);
            await col.DeleteOneAsync(filter);
        }

    }
}
