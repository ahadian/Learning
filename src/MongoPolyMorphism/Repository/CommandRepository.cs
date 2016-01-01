// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeliseAppSuitesDataDefinationCommandRepository.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using Selise.AppSuite.DataDefination.Core.PrimaryEntities;


namespace Selise.AppSuite.MongoDbDataContext.RepositoryImpls
{
    using MongoDB.Bson;
    using MongoDB.Bson.IO;
    using MongoDB.Driver;


    public class CommandRepository
    {
        private readonly Repository.MongoDbDataContext _dataContext;


        public CommandRepository(string dbName)
        {
            this._dataContext = new Repository.MongoDbDataContext(dbName);
        }


        public void Insert(string entity, object primaryEntity)
         {
             IMongoCollection<BsonDocument> collection = this._dataContext.GetCollection(entity);

            //return;

             //IMongoCollection<ContentTile> _collection = this._dataContext.GetCollection<ContentTile>();
            //collection.InsertOneAsync(connection);
            collection.InsertOneAsync(primaryEntity.ToBsonDocument());
        }

        public void Update(string entity, object primaryEntity)
        {
            IMongoCollection<BsonDocument> collection = this._dataContext.GetCollection(entity);
            var filter = DataHelpers.CreateDocumentIDFilter(primaryEntity);
            collection.ReplaceOneAsync(filter, primaryEntity.ToBsonDocument());
        }

        public void Insert<T>(dynamic[] arr)
        {
            var run = typeof(Repository.MongoDbDataContext).GetMethod("GetCollection", new Type[] { });

            Type t = typeof(T);
            MethodInfo generic = run.MakeGenericMethod(t);
            var result = generic.Invoke(new Repository.MongoDbDataContext("MongoPolyMorphism"), new Type[] { });
            var finalMethod = result.GetType().GetMethod("InsertOneAsync", new[] { typeof(T), typeof(CancellationToken) });
            finalMethod.Invoke(result, new[] { Activator.CreateInstance(typeof(T),arr) , null});
        }
    }

    public static class DataHelpers
    {
        public static FilterDefinition<BsonDocument> CreateDocumentIDFilter(string entityID)
        {
            return Builders<BsonDocument>.Filter.Eq("_id", entityID);
        }

        public static FilterDefinition<BsonDocument> CreateDocumentIDFilter(object entityObject)
        {
            return Builders<BsonDocument>.Filter.Eq("_id", GetObjectID(entityObject));
        }

        public static string GetObjectID(object @object)
        {
            return (string)@object.GetType().GetProperty("ItemId").GetValue(@object);
        }
    }
}