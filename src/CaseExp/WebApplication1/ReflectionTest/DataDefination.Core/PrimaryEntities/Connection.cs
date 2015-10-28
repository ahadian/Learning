// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Connection.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    #region

    

    #endregion

    public class Connection : IEntity
    {
        #region Public Properties

        public string ChildEntityID { get; set; }

        public string ChildEntityName { get; set; }

        public string ConnectionID { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public string Id { get; set; }

        public string Language { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string ModofiedBy { get; set; }

        public string ParentEntityID { get; set; }

        public string ParentEntityName { get; set; }

        #endregion
    }
}