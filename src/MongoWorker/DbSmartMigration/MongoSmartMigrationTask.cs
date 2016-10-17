using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Infrastructure;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace DbSmartMigration
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
    public class MongoSmartMigrationTask : IMongoTask
    {
        private MongoSmartMigrationCommand mongoSmartMigrationCommand;
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        public MongoSmartMigrationTask()
        {
            this.mongoSmartMigrationCommand = new MongoSmartMigrationCommand { Host = this.MongoCommand.Host, Port = this.MongoCommand.Port }; 
        }

        public override void TakeInput()
        {
        }

        public override void PeroformTask()
        {
            string binPath = AppDomain.CurrentDomain.BaseDirectory;
            string jsonPath = string.Format(@"{0}\{1}", binPath, "DefaultValueSeed.json");
            List<MigrationSettings> defaultValueSeed;
            using (StreamReader r = new StreamReader(jsonPath))
            {
                string json = r.ReadToEnd();
                defaultValueSeed = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MigrationSettings>>(json);
            }
            List<string> databases = new List<string>();
            List<string> collections = new List<string>();
            MongoUpdateHandler mongoUpdateHandler = new MongoUpdateHandler();
            foreach (var migrationSettings in defaultValueSeed)
            {
                databases = migrationSettings.Databasenames.Contains("*") ? this.GetAllDatabasesInAHost(this.mongoSmartMigrationCommand.Host, this.mongoSmartMigrationCommand.Port) : migrationSettings.Databasenames.ToList();
                foreach (var database in databases)
                {
                    collections = migrationSettings.CollectionNames.Contains("*") ? this.GetAllCollections(this.mongoSmartMigrationCommand.Host, this.mongoSmartMigrationCommand.Port, database) : migrationSettings.CollectionNames.ToList();
                    foreach (var col in collections)
                    {
                        UpdateCommand command = new UpdateCommand()
                        {
                            Host = this.mongoSmartMigrationCommand.Host,
                            Port = this.mongoSmartMigrationCommand.Port,
                            DatabaseName = database,
                            CollectionName = col,
                            MongQuery = migrationSettings.MongoQuery,
                            Changes = migrationSettings.Changes
                        };
                        mongoUpdateHandler.Handle(command);
                    }
                }
            }
        }

        private List<string> GetAllCollections(string host, int port, string db)
        {
            //throw new NotImplementedException();
            _client = new MongoClient(string.Format("mongodb://{0}:{1}", host, port));
            _database = _client.GetDatabase(db);
            var x = _database.ListCollections().ToList();
            List<ColInfo> colInfos = new List<ColInfo>();
            foreach (var doc in x)
            {
                var data = (ColInfo)BsonSerializer.Deserialize(doc, typeof(ColInfo), null);
                colInfos.Add(data);
            }
            var res = colInfos.Select(xx => xx.Name).ToList();
            return res;
        }

        private List<string> GetAllDatabasesInAHost(string host, int port)
        {
            _client = new MongoClient(string.Format("mongodb://{0}:{1}", host, port));
            var listDatabases = _client.ListDatabases();
            List<BsonDocument> x = listDatabases.ToList();
            List<DbInfo> dbInfo = new List<DbInfo>();
            foreach (var doc in x)
            {
                var data = (DbInfo)BsonSerializer.Deserialize(doc, typeof(DbInfo), null);
                dbInfo.Add(data);
            }
            var res = dbInfo.Select(xx => xx.Name).ToList();
            return res;
        }

        public override void ProduceOutput()
        {
            Console.WriteLine("Smart migration is successfully completed...");
            Console.ReadLine();
        }

        private void ReadCollectionName()
        {
            Console.WriteLine("Enter Collection Name : ");
            this.mongoSmartMigrationCommand.CollectionName = Console.ReadLine();
        }

        private void ReadDatabaseName()
        {
            Console.WriteLine("Enter Database Name : ");
            this.mongoSmartMigrationCommand.DatabaseName = Console.ReadLine();
        }

        private string GetProcessName()
        {
            string dir = @"C:\Program Files\MongoDB\Server\3.2\bin\"; // Codesmell : should come form a config file
            string processName = "mongorestore.exe";
            string fileName = string.Format(@"{0}{1}", dir, processName);
            if (!File.Exists(fileName))
            {
                Console.WriteLine("{0} not found in = {1}.", processName, dir);
                throw new Exception();
            }
            return fileName;
        }
    }
}
