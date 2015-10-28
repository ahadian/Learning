// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core
{
    #region

    

    #endregion

    public interface IEntity
    {
        #region Public Properties


        DateTime CreateDate { get; set; }


        string CreatedBy { get; set; }


        string Id { get; set; }


        string Language { get; set; }


        DateTime LastUpdateDate { get; set; }


        string ModofiedBy { get; set; }

        #endregion
    }
}