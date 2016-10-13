using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DdSmartMigration_
{
    public class UpdateCommand
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }

        public string MongQuery { get; set; }

        public List<Change> Changes { get; set; }

    }
    public class MongoUpdateHandler
    {
        public void Handle(UpdateCommand command)
        {
            IMongoClient _client = new MongoClient(string.Format("mongodb://{0}:{1}", command.Host, command.Port));
            IMongoDatabase _database = _client.GetDatabase(command.DatabaseName);
            string binPath = AppDomain.CurrentDomain.BaseDirectory;
            string jsonPath = string.Format(@"{0}\{1}", binPath, "DefaultValueSeed.json");
            var collection = _database.GetCollection<BsonDocument>(command.CollectionName);
            BsonDocument document = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(command.MongQuery);
            UpdateDefinition<BsonDocument> upd = null;
            foreach (var change in command.Changes)
            {
                upd = HelpMeWithParsing(upd, change);
            }

            var allData = collection.Find(document).ToList();
            foreach (var data in allData)
            {
                collection.UpdateOne(data, upd);
            }
        }
        static UpdateDefinition<BsonDocument> HelpMeWithParsing(UpdateDefinition<BsonDocument> upd, Change change)
        {
            if (upd == null)
            {
                if ("int".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Builders<BsonDocument>.Update.Set(change.PropertyName, ValueParser.ParseInt(change.Value));
                }
                if ("double".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Builders<BsonDocument>.Update.Set(change.PropertyName, ValueParser.ParseDouble(change.Value));
                }
                if ("string".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Builders<BsonDocument>.Update.Set(change.PropertyName, change.Value);
                }
                if ("date".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Builders<BsonDocument>.Update.Set(change.PropertyName, ValueParser.ParseDate(change.Value));
                }
                if ("int[]".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Builders<BsonDocument>.Update.Set(change.PropertyName, ValueParser.ParseIntArray(change.Value));
                }
                if ("string[]".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Builders<BsonDocument>.Update.Set(change.PropertyName, ValueParser.ParseStringArray(change.Value));
                }
            }
            else
            {
                if ("int".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return upd.Set(change.PropertyName, ValueParser.ParseInt(change.Value));
                }
                if ("double".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return upd.Set(change.PropertyName, ValueParser.ParseDouble(change.Value));
                }
                if ("string".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return upd.Set(change.PropertyName, change.Value);
                }
                if ("date".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return upd.Set(change.PropertyName, ValueParser.ParseDate(change.Value));
                }
                if ("int[]".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return upd.Set(change.PropertyName, ValueParser.ParseIntArray(change.Value));
                }
                if ("string[]".Equals(change.Type, StringComparison.InvariantCultureIgnoreCase))
                {
                    return upd.Set(change.PropertyName, ValueParser.ParseStringArray(change.Value));
                }

            }
            return null;

        }
    }
}
