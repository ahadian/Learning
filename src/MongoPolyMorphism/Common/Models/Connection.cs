// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Connection.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Selise.AppSuite.DataDefination.Core.PrimaryEntities
{
    #region

    using System;

    #endregion

    public class Connection : IEntity
    {
        #region Public Properties

        public string ChildEntityID { get; set; }

        public string ChildEntityName { get; set; }

        public override DateTime CreateDate { get; set; }

        public override string CreatedBy { get; set; }

        public override string Language { get; set; }

        public override DateTime LastUpdateDate { get; set; }

        public override string LastUpdatedBy { get; set; }

        public string ParentEntityID { get; set; }

        public string ParentEntityName { get; set; }

        public override string TenantId { get; set; }

        #endregion

        #region Public Methods and Operators

        public static Connection Create(
            string parentEntityName, 
            string childEntityName, 
            string parentEntityID, 
            string childEntityID, 
            string itemId, 
            string tenantId)
        {
            return new Connection
                       {
                           ChildEntityID = childEntityID, 
                           ChildEntityName = childEntityName, 
                           ParentEntityID = parentEntityID, 
                           ParentEntityName = parentEntityName, 
                           ItemId = itemId, 
                           TenantId = tenantId
                       };
        }

        public static Connection CreateFromID(string itemId, string tenantId)
        {
            return new Connection
                       {
                           ChildEntityID = string.Empty, 
                           ChildEntityName = string.Empty, 
                           ItemId = itemId, 
                           ParentEntityID = string.Empty, 
                           ParentEntityName = string.Empty, 
                           TenantId = tenantId
                       };
        }

        #endregion
    }
}