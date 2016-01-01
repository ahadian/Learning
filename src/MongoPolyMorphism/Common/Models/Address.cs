// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Selise.AppSuite.DataDefination.Core.PrimaryEntities
{
    #region

    using System;

    #endregion

    public class Address : IEntity
    {
        #region Public Properties

        public string City { get; set; }

        public string Country { get; set; }

        public override DateTime CreateDate { get; set; }

        public override string CreatedBy { get; set; }

        public override string Language { get; set; }

        public override DateTime LastUpdateDate { get; set; }

        public override string LastUpdatedBy { get; set; }

        public string State { get; set; }

        public string StreetAddress { get; set; }

        public override string TenantId { get; set; }

        public string ZipCode { get; set; }

        #endregion
    }
}