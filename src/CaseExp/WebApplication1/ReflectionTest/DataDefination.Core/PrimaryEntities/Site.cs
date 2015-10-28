// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Site.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    #region

    

    #endregion

    public class Site : IEntity
    {
        // User view host : htttp://mango.fruits.com
        #region Public Properties

        public string HostName { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public string Favicon { get; set; }

        public string HeaderSubtitle { get; set; }

        public string HeaderTitle { get; set; }

        public string Id { get; set; }

        public string IsAdmin { get; set; }

        public string Language { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string Logo { get; set; }

        public string MetaDescription { get; set; }

        public string[] MetaKeywords { get; set; }

        public string ModofiedBy { get; set; }

        public string Name { get; set; }

        public string TenantID { get; set; }

        public string Template { get; set; } 

        public string WindowTitle { get; set; }

        public string Theme { get; set; }


        #endregion
    }
}