using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeSound
{
    public class Sound
    {
        [BsonId]
        public int id { get; set; }
        public string name { get; set; }
        public string license { get; set; }
        public string username { get; set; }
        public string[] tags { get; set; }
        public bool isDownloaded { get; set; }

        public Sound()
        {
            isDownloaded = false;
        }
    }
}
