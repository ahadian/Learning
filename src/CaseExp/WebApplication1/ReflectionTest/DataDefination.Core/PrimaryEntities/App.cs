// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    #region

    using System;

    #endregion

    public class App : IEntity
    {
        #region Public Properties

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public string Id { get; set; }

        public string Language { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string ModofiedBy { get; set; }

        public string Name { get; set; }

        public string ParentEntityId { get; set; }

        public string[] Features { get; set; }

        public string Type { get; set; }

        #endregion
    }
}