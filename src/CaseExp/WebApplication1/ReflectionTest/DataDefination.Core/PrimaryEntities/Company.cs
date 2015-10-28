// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Company.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    #region

    

    #endregion

    public class Company : IEntity
    {
        #region Public Properties

        public string Address { get; set; }

        public string BusinessRegistrationNumber { get; set; }

        public string BusinessSector { get; set; }

        public string CompanyName { get; set; }

        public string CompanyType { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public string Description { get; set; }

        public string Earnings { get; set; }

        public string FoundingYear { get; set; }

        public string Id { get; set; }

        public string Language { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string LogoUrl { get; set; }

        public string ModofiedBy { get; set; }

        public string NumberOfFullTimeEmployee { get; set; }

        public string Website { get; set; }

        public string YearlyTurnover { get; set; }

        #endregion
    }
}