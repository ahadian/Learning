// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataItem.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Selise.AppSuite.DataDefination.Core.PrimaryEntities
{
    #region

    using System;

    #endregion

    public class DataItem : IEntity
    {
        #region Public Properties

        public override DateTime CreateDate { get; set; }

        public override string CreatedBy { get; set; }

        public string DataItemName { get; set; }

        public string DataType { get; set; }

        public bool Include { get; set; }

        public override string Language { get; set; }

        public override DateTime LastUpdateDate { get; set; }

        public override string LastUpdatedBy { get; set; }

        public override string TenantId { get; set; }

        #endregion

        #region Public Methods and Operators

        public static DataItem Create(
            string itemId, 
            string dataItemName, 
            string dataType, 
            bool Include, 
            string tenantId)
        {
            return new DataItem
                       {
                           DataItemName = dataItemName, 
                           DataType = dataType, 
                           Include = Include, 
                           ItemId = itemId, 
                           TenantId = tenantId
                       };
        }

        #endregion
    }
}