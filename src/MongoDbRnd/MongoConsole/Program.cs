using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
namespace MongoConsole
{

    class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        static void Main(string[] args)
        {
            string connectionstring = "mongodb://172.16.0.223:27017";
            _client = new MongoClient(connectionstring);
            _database = _client.GetDatabase("200DE79B-DCCD-4965-BC93-0A6A8E6AE355");
        }
    }
}
