// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvestmentRequest.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    #region

    

    #endregion

    public class InvestmentRequest : IEntity
    {
        #region Public Properties

        public float ComittedAmount { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public string Id { get; set; }

        public string Language { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string ModofiedBy { get; set; }

        public string RequestStatus { get; set; }

        #endregion
    }
}