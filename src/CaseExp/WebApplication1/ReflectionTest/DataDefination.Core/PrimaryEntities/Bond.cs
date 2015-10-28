// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bond.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    #region

    

    #endregion

    public class Bond : IEntity
    {
        #region Public Properties

        public string ApprovedBy { get; set; }

        public string BondStatus { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public string Id { get; set; }

        public string Language { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string MimimumInvesmentAmount { get; set; }

        public string ModofiedBy { get; set; }

        public string OfferingAmount { get; set; }

        public string Purpose { get; set; }

        public string TermMaturity { get; set; }

        #endregion
    }
}