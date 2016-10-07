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
    class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        static void Main(string[] args)
        {
            //_client = new MongoClient("mongodb://172.16.0.59:27017");
            //var listDatabases = _client.ListDatabases();
            //List<BsonDocument> x = listDatabases.ToList();
            //List<DbInfo> dbInfo = new List<DbInfo>();
            //foreach (var doc in x)
            //{
            //    var data = (DbInfo)BsonSerializer.Deserialize(doc, typeof(DbInfo), null);
            //    dbInfo.Add(data);
            //}
            //_database = _client.GetDatabase("test");
            //var database = _client.GetDatabase("admin");
            //var cc = database.ListCollections().ToList();
            //var command = new BsonDocumentCommand<BsonDocument>(new BsonDocument("listDatabases", 1));
            //var command2 = new BsonDocumentCommand<BsonDocument>(new BsonDocument("listDatabases", 1));
            //var commandResult = database.RunCommand(command);

            Console.WriteLine("Select an option : ");
            Console.WriteLine("1. Dump");
            Console.WriteLine("2. Restore");
            Console.WriteLine("3. Create a new Tenant");
            IMongoTask mongoTask;
            IMongoTaskRunner<IMongoTask> mongoTaskRunner;
            string commnad = Console.ReadLine();
            if ("1".Equals(commnad))
            {
                mongoTask = new MongoDumpTask();
                new MongoDumpTaskRunner<IMongoTask>().Runtask(mongoTask);
            }
        }
    }
}
