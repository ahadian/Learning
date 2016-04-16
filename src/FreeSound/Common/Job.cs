using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeSound
{
    public class Job
    {
        [BsonId]
        public string ItemId { get; set; }

        public string Tag { get; set; }

        public string Status { get; set; }

        public int NumberOfItemsToDownload { get; set; }
    }
}
