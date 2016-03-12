using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Selise.AppSuite.DataDefination.Core.PrimaryEntities
{
    public class Post : IEntity
    {
        public override DateTime CreateDate { get; set; }

        public override string CreatedBy { get; set; }

        public override string Language { get; set; }

        public override DateTime LastUpdateDate { get; set; }

        public override string LastUpdatedBy { get; set; }

        public override string TenantId { get; set; }

        public string Body { get; set; }
        public string Url { get; set; }
        public string UrlPreview { get; set; }
        public string Type { get; set; }
        public string ResourceId { get; set; }
    }
}
