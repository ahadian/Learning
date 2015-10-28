// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tenant.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    #region

    

    #endregion

    public class Tenant : IEntity
    {
        #region Public Properties

        public string Copyright { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public string Id { get; set; }

        public string Language { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string ModofiedBy { get; set; }

        public string OwnerName { get; set; }

        public string TenantDb { get; set; }

        public string TenantName { get; set; }

        #endregion
    }
}