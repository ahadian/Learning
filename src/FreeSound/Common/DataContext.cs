using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FreeSound
{
    public class DataContext
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        public DataContext()
        {
            _client = new MongoClient(ConfigurationSettings.AppSettings["MongodbConnectionString"]);
            _database = _client.GetDatabase("freeSound");
        }

        public Job NextJob()
        {
            var collection = _database.GetCollection<Job>("PendingJobs");
            var job = collection.Find(new BsonDocument()).Limit(1);
            if (job == null) return null;
            //collection.DeleteOne(Builders<Job>.Filter.Eq("ItemId",job.ItemId));
            return job.FirstOrDefault();
        }

        public Sound GetNextSoundToDownload()
        {
            var collection = _database.GetCollection<Sound>("Sounds");
            var filter = Builders<Sound>.Filter.Eq("isDownloaded", false);
            var sound = collection.Find(filter).Limit(1);
            if (sound == null) return null;
            //collection.DeleteOne(Builders<Job>.Filter.Eq("ItemId",job.ItemId));
            return sound.FirstOrDefault();
        }

        public void MarkSoundAsDownloaded(Sound sound)
        {
            var collection = _database.GetCollection<Sound>("Sounds");
            var filter = Builders<Sound>.Filter.Eq("_id", sound.id);
            var update = Builders<Sound>.Update.Set("isDownloaded", true);
            var result = collection.UpdateOne(filter, update);
        }

        public void EnqueueJob(Job job)
        {
            var collection = _database.GetCollection<Job>("PendingJobs");
            bool newJob = collection.Find(Builders<Job>.Filter.Eq("ItemId", job.ItemId)).Limit(1).Count() == 0;
            if (!newJob) return;
            collection.InsertOne(job);
        }

        public void ArchiveJob(Job job)
        {
            var collection = _database.GetCollection<Job>("PendingJobs");
            var filter = Builders<Job>.Filter.Eq("ItemId", job.ItemId);
            bool jobExists = collection.Find(filter).SingleOrDefault() != null;
            if (jobExists)
            {
                collection.DeleteOne(filter);
                collection = _database.GetCollection<Job>("ArchivedJobs");
                collection.InsertOne(job);
            }
        }

        public void InsertManySound(Sound[] sounds)
        {
            var collection = _database.GetCollection<Sound>("Sounds");
            collection.InsertMany(sounds);
        }
        public void InsertSound(Sound sound)
        {
            var collection = _database.GetCollection<Sound>("Sounds");
            collection.InsertOne(sound);
        }

    }
}
