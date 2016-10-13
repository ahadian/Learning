using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBackUp
{
    public class MongoRestoreCommand : MongoCommand
    {
        public string OutputDirectory { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }

        private const string FullDump = "--host {0} --port {1} --dir {2}";
        private const string DumpADatabase = "--host {0} --port {1} --db {2} --dir {3}";
        private const string DumpACollection = "--host {0} --port {1} --db {2} --collection {3} --dir {4}";
        public override string BuildCommand()
        {
            if ("*".Equals(this.DatabaseName)) return string.Format(FullDump, this.Host, this.Port, this.OutputDirectory);
            if ("*".Equals(this.CollectionName)) return string.Format(DumpADatabase, this.Host, this.Port, this.DatabaseName, this.OutputDirectory);
            return string.Format(DumpACollection, this.Host, this.Port, this.DatabaseName, this.CollectionName, this.OutputDirectory);
        }
    }

}
