// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MongoDbDataContext.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Repository
{
    #region

    

    #endregion

    public class MongoDbDataContext 
    {
        #region Fields

        private readonly IMongoDatabase mongoDbDatabase;

        #endregion

        #region Constructors and Destructors

        public MongoDbDataContext(string tenentDatabase)
        {
            var connectionString = "mongodb://localhost:27017";
            this.mongoDbDatabase =
                new MongoClient(connectionString).GetDatabase(tenentDatabase);
         
        }

        public MongoDbDataContext()
        {
            
        }

        #endregion

        #region Public Properties

        public IMongoDatabase MongoDbDatabase
        {
            get
            {
                return this.mongoDbDatabase;
            }
        }

        #endregion

        #region Public Methods and Operators

        //public IMongoCollection<T> GetCollection<T>()
        //{
        //    Type type = typeof(T);

        //    return this.mongoDbDatabase.GetCollection<T>(string.Format("{0}s", type.Name));
        //}
        public object GetCollection<T>()
        {
            Type type = typeof(T);

            return this.mongoDbDatabase.GetCollection<T>(string.Format("{0}s", type.Name));
        }
        public IMongoCollection<BsonDocument> GetCollection(string entityName)
        {
            return this.mongoDbDatabase.GetCollection<BsonDocument>(string.Format("{0}s", entityName));
        }

        public void Test<T>()
        {
            Console.WriteLine(typeof(T));
        }
        #endregion
    }
}