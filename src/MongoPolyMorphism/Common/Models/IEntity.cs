// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Selise.AppSuite.DataDefination.Core
{
    #region

    using System;

    using MongoDB.Bson.Serialization.Attributes;

    #endregion

    [BsonIgnoreExtraElements]
    public class IEntity
    {
        #region Public Properties

        public virtual DateTime CreateDate { get; set; }

        public virtual string CreatedBy { get; set; }

        [BsonId]
        public string ItemId { get; set; }

        public virtual string Language { get; set; }

        public virtual DateTime LastUpdateDate { get; set; }

        public virtual string LastUpdatedBy { get; set; }

        public string[] Tags { get; set; }

        public virtual string TenantId { get; set; }

        #endregion
    }
}