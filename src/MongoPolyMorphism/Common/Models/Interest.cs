// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Interest.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Selise.AppSuite.DataDefination.Core.PrimaryEntities
{
    #region

    using System;

    #endregion

    public class Interest : IEntity
    {
        #region Public Properties

        public override DateTime CreateDate { get; set; }

        public override string CreatedBy { get; set; }

        public string InterestName { get; set; }

        public override string Language { get; set; }

        public override DateTime LastUpdateDate { get; set; }

        public override string LastUpdatedBy { get; set; }

        public override string TenantId { get; set; }

        #endregion
    }
}