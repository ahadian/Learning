using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Change
    {
        public string PropertyName { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }
    public class MigrationSettings
    {
        public string[] Databasenames { get; set; }

        public string[] CollectionNames { get; set; }

        public string MongoQuery { get; set; }

        public List<Change> Changes { get; set; }

    }
}
