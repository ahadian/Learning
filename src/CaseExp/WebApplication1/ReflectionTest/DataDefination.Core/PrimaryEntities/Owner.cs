// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Owner.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    #region

    

    #endregion

    public class Owner : IEntity
    {
        #region Public Properties

        public string BusinessNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public string DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public string FullName { get; set; }

        public string Id { get; set; }

        public string Language { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string MobileNumber { get; set; }

        public string ModofiedBy { get; set; }

        #endregion
    }
}