using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbBackUp;

namespace Infrastructure
{
    public abstract class IMongoTask
    {

        protected MongoCommand MongoCommand { get; set; }

        protected void InitServer()
        {
            this.MongoCommand = new MongoCommand();
            Console.WriteLine("Enter Server : ");
            // Code smell , no validation :D
            this.MongoCommand.Host = Console.ReadLine();
            Console.WriteLine("Enter port : ");
            // Code smell , no validation :D
            string p = Console.ReadLine();
            int port = 0;
            int.TryParse(p, out port);
            if (port != 0) this.MongoCommand.Port = port;
        }
        public abstract void TakeInput();

        public abstract void BuildTask();

        public abstract void PeroformTask();

        public abstract void ProduceOutput();
    }

    public interface IMongoTaskRunner<T> where T : IMongoTask
    {
        void Runtask(T mongoTask);
    }
}
