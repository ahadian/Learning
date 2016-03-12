// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContentTile.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

namespace Selise.AppSuite.DataDefination.Core.PrimaryEntities
{
    #region

    using System;

    #endregion

    public class ContentTile : IEntity
    {
        #region Public Properties

        public override DateTime CreateDate { get; set; }

        public override string CreatedBy { get; set; }

        public string ImageUrl { get; set; }

        public bool IsPublished { get; set; }

        public override string Language { get; set; }

        public override DateTime LastUpdateDate { get; set; }

        public override string LastUpdatedBy { get; set; }

        public string LongText { get; set; }

        public string ModifiedBy { get; set; }

        public string ShortText { get; set; }

        public override string TenantId { get; set; }

        public ContentTile()
        {
            
        }

        public ContentTile(Object src, object _null)
        {
            foreach (PropertyDescriptor item in TypeDescriptor.GetProperties(src))
            {
                item.SetValue(this, item.GetValue(src));
            } 
        }

        #endregion
    }
}

/*
* 
* 
* 
* 
* Tags []
 */