using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDbDataContext
{
    public class MongoDbDataContext
    {
        #region Fields

        private readonly IMongoDatabase _mongoDbDatabase;

        #endregion

        #region Constructors and Destructors

        public MongoDbDataContext(string tenentDatabase)
        {
            this._mongoDbDatabase =
                new MongoClient(ConfigurationManager.AppSettings["MongoDbConnectionString"]).GetDatabase(tenentDatabase);

        }

        #endregion

        #region Public Properties

        public IMongoDatabase MongoDbDatabase
        {
            get
            {
                return this._mongoDbDatabase;
            }
        }

        #endregion

        #region Public Methods and Operators

        public IMongoCollection<T> GetCollection<T>()
        {
            Type type = typeof(T);

            return this._mongoDbDatabase.GetCollection<T>(string.Format("{0}s", type.Name));
        }

        public IMongoCollection<BsonDocument> GetCollection(string entityName)
        {
            return this._mongoDbDatabase.GetCollection<BsonDocument>(string.Format("{0}s", entityName));
        }

        #endregion
    }
}
