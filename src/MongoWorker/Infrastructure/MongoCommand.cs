using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace DbBackUp
{
    public class MongoCommand
    {
        public string Host { get; set; }

        private int? port;

        public int Port
        {
            get { return this.port ?? 27017; }
            set { this.port = value; }
        }

        public virtual string BuildCommand()
        {
            throw new Exception("No enough info to build command");
        }

    }
}
