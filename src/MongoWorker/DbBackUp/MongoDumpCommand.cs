using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBackUp
{
    public class MongoDumpCommand : MongoCommand
    {
        public string OutputDirectory { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }

        private const string Fullrestore = "--host {0} --port {1} --out {2}";
        private const string RestoreADatabase = "--host {0} --port {1} --db {2} --out {3}";
        private const string RestoreACollection = "--host {0} --port {1} --db {2} --collection {3} --out {4}";
        public override string BuildCommand()
        {
            if ("*".Equals(this.DatabaseName)) return string.Format(Fullrestore, this.Host, this.Port, this.OutputDirectory);
            if ("*".Equals(this.CollectionName)) return string.Format(RestoreADatabase, this.Host, this.Port, this.DatabaseName, this.OutputDirectory);
            return string.Format(RestoreACollection, this.Host, this.Port, this.DatabaseName, this.CollectionName, this.OutputDirectory);
        }
    }
}
