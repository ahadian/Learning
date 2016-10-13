using System;
using DbBackUp;

namespace Infrastructure
{
    public abstract class IMongoTask
    {
        protected IMongoTask()
        {
            this.InitServer();
        }
        protected MongoCommand MongoCommand { get; private set; }
        // enforcement missing

        protected void InitServer()
        {
            this.MongoCommand = new MongoCommand();
            Console.WriteLine("Enter Server : ");
            this.MongoCommand.Host = Console.ReadLine();// Code smell , no validation :D
            Console.WriteLine("Enter port : ");
            string p = Console.ReadLine();// Code smell , no validation :D
            int port = 0;
            int.TryParse(p, out port);
            if (port != 0) this.MongoCommand.Port = port;
        }

        public abstract void TakeInput();

        public abstract void PeroformTask();

        public abstract void ProduceOutput();
    }
}