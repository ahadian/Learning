using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbBackUp;
using Infrastructure;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoWorker
{
    public class DbInfo
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("sizeOnDisk")]
        public double SizeOnDisk { get; set; }
        [BsonElement("empty")]
        public bool Empty { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class ColInfo
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }

    class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        static void Main(string[] args)
        {
            _client = new MongoClient("mongodb://172.16.0.59:27017");
            var listDatabases = _client.ListDatabases();
            List<BsonDocument> x = listDatabases.ToList();
            List<DbInfo> dbInfo = new List<DbInfo>();
            foreach (var doc in x)
            {
                var data = (DbInfo)BsonSerializer.Deserialize(doc, typeof(DbInfo), null);
                dbInfo.Add(data);
            }
            _database = _client.GetDatabase("200DE79B-DCCD-4965-BC93-0A6A8E6AE355");
            var cc = _database.ListCollections().ToList();


            List<ColInfo> colInfo = new List<ColInfo>();
            foreach (var doc in cc)
            {
                var data = (ColInfo)BsonSerializer.Deserialize(doc, typeof(ColInfo), null);
                colInfo.Add(data);
            }
        }
    }
}
