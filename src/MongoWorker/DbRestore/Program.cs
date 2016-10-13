//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Infrastructure;
//using MongoDB.Bson;
//using MongoDB.Bson.IO;
//using MongoDB.Bson.Serialization;
//using MongoDB.Driver;

//namespace DbRestore
//{
//    class Program
//    {
//        protected static IMongoClient _client;
//        protected static IMongoDatabase _database;
//        static void Main(string[] args)
//        {
//            _client = new MongoClient("mongodb://172.16.0.202:27017");
//            var listDatabases = _client.ListDatabases();
//            //List<BsonDocument> x = listDatabases.ToList();
//            //foreach (var doc in x)
//            //{
//            //    var data = (DbInfo)BsonSerializer.Deserialize(doc, typeof(DbInfo), null);
//            //    dbInfo.Add(data);
//            //}
//            _database = _client.GetDatabase("200DE79B-DCCD-4965-BC93-0A6A8E6AE355");
//            var collection = _database.GetCollection<BsonDocument>("Addresss");

//            //UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update
//            //    .Set("TenantId", "__test__");
//            //var allData = collection.Find(new BsonDocument()).ToList();
//            //foreach (var data in allData)
//            //{
//            //    var x = collection.UpdateOne(data, update);

//            //}
//            string binPath = AppDomain.CurrentDomain.BaseDirectory;
//            string jsonPath = string.Format(@"{0}\{1}", binPath, "DefaultValueSeed.json");
//            List<MigrationSettings> defaultValueSeed;
//            using (StreamReader r = new StreamReader(jsonPath))
//            {
//                string json = r.ReadToEnd();
//                defaultValueSeed = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MigrationSettings>>(json);
//            }

//            foreach (var settings in defaultValueSeed)
//            {
//                collection = _database.GetCollection<BsonDocument>(settings.CollectionNames);
//                MongoDB.Bson.BsonDocument document =
//                    MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(settings.MongoQuery);
//                var allData = collection.Find(settings.MongoQuery).ToList();
//                UpdateDefinition<BsonDocument> upd = null;
//                foreach (var change in settings.Changes)
//                {
//                    upd = HelpMeWithParsing(upd, change);
//                }
//                foreach (var data in allData)
//                {
//                    collection.UpdateOne(data, upd);
//                }
//                int u = 0;
//            }
//            //var database = _client.GetDatabase("admin");
//            //var cc = database.ListCollections().ToList();
//            //var command = new BsonDocumentCommand<BsonDocument>(new BsonDocument("listDatabases", 1));
//            //var command2 = new BsonDocumentCommand<BsonDocument>(new BsonDocument("listDatabases", 1));
//            //var commandResult = database.RunCommand(command);
//        }

//        static UpdateDefinition<BsonDocument> HelpMeWithParsing(UpdateDefinition<BsonDocument> upd, Change change)
//        {
//            if (upd == null)
//            {
//                if ("int".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    return Builders<BsonDocument>.Update.Set(change.PropertyName, ValueParser.ParseInt(change.Value));
//                }
//                if ("string".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    return Builders<BsonDocument>.Update.Set(change.PropertyName, change.Value);
//                }
//                if ("date".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    return Builders<BsonDocument>.Update.Set(change.PropertyName, ValueParser.ParseDate(change.Value));
//                }
//                if ("int[]".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    return Builders<BsonDocument>.Update.Set(change.PropertyName, ValueParser.ParseIntArray(change.Value));
//                }
//                if ("string[]".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    return Builders<BsonDocument>.Update.Set(change.PropertyName, ValueParser.ParseStringArray(change.Value));
//                }
//            }
//            else
//            {
//                if ("int".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    return upd.Set(change.PropertyName, ValueParser.ParseInt(change.Value));
//                }
//                if ("string".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    return upd.Set(change.PropertyName, change.Value);
//                }
//                if ("date".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    return upd.Set(change.PropertyName, ValueParser.ParseDate(change.Value));
//                }
//                if ("int[]".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    return upd.Set(change.PropertyName, ValueParser.ParseIntArray(change.Value));
//                }
//                if ("string[]".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    return upd.Set(change.PropertyName, ValueParser.ParseStringArray(change.Value));
//                }

//            }
//            return null;

//        }
//        private static object GetValue(Change change)
//        {
//            if (string.IsNullOrWhiteSpace(change.Type)) throw new Exception(string.Format("Failed to discover actual type for property = {0}", change.PropertyName));
//            if ("int".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//            {
//                int res = 0;
//                int.TryParse(change.Value, out res);
//                return res;
//            }
//            if ("string".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//            {
//                return change.Value;
//            }
//            if ("date".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//            {
//                if (string.IsNullOrWhiteSpace(change.Value)) return DateTime.MinValue;
//                if ("utc".Equals(change.Value, StringComparison.InvariantCultureIgnoreCase))
//                {
//                    return DateTime.UtcNow;
//                }
//                else
//                {
//                    return DateTime.Parse(change.Value).ToUniversalTime();
//                }
//            }
//            List<object> li = new List<object>();
//            if ("int[]".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//            {
//                List<int> val = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(change.Value);
//                li.AddRange(val.Cast<object>());
//                return li.ToArray();
//            }
//            if ("string[]".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
//            {
//                List<string> val = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(change.Value);
//                return val.ToArray();
//            }

//            return null;
//        }
//    }
//}
