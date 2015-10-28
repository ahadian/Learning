// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    #region

    

    #endregion

    public class Person : IEntity
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

        public string Url { get; set; }

        #endregion
    }
}