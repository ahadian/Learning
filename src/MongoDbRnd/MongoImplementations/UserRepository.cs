using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoImplementations
{
    public class UserRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public UserRepository()
        {
            string connectionstring = "mongodb://172.16.0.223:27017";
            _client = new MongoClient(connectionstring);
            _database = _client.GetDatabase("200DE79B-DCCD-4965-BC93-0A6A8E6AE355");
        }

        public bool RemoveUserbyId(string userId)
        {
            //string mycollectionCount _database.Eval("function() { return db.mycollection.count(); }").ToString();
            //_database.GetCollection<Users>()
        }
    }
}
