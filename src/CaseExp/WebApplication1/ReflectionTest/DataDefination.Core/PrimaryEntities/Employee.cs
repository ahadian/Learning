// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Employee.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    public class Employee : IEntity
    {
        #region Public Properties

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public string Id { get; set; }

        public string Language { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string ModofiedBy { get; set; }

        public string address { get; set; }

        public string age { get; set; }

        public string height { get; set; }

        public string name { get; set; }


        public string salary { get; set; }

        public string sex { get; set; }

        #endregion
    }
}