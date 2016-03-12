// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entity.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Selise.AppSuite.DataDefination.Core.PrimaryEntities
{
    #region

    using System;

    #endregion

    public class Entity : IEntity
    {
        #region Public Properties

        public string[] ConnectableEntities { get; set; }

        public override DateTime CreateDate { get; set; }

        public override string CreatedBy { get; set; }

        public DataItem[] DataItems { get; set; }

        public string EntityName { get; set; }

        public override string Language { get; set; }

        public override DateTime LastUpdateDate { get; set; }

        public override string LastUpdatedBy { get; set; }

        public string PrimaryEntityName { get; set; }

        public override string TenantId { get; set; }

        #endregion

        #region Public Methods and Operators

        public static Entity Create(
            string entityName, 
            string primaryEntityName, 
            DataItem[] dataItems, 
            string[] connectableEntities, 
            string itemId, 
            string tenantId)
        {
            return new Entity
                       {
                           ConnectableEntities = connectableEntities ?? new string[] { }, 
                           DataItems = dataItems, 
                           EntityName = entityName, 
                           PrimaryEntityName = primaryEntityName, 
                           ItemId = itemId, 
                           TenantId = tenantId
                       };
        }

        #endregion
    }
}