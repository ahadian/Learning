using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace DbBackUp
{
    public class MongoDumpTask : IMongoTask
    {
        private MongoDumpCommand mongoDumpCommand;
        public MongoDumpTask()
        {
            this.InitServer();
            this.mongoDumpCommand = new MongoDumpCommand();
            this.mongoDumpCommand.Host = this.MongoCommand.Host;
            this.mongoDumpCommand.Port = this.MongoCommand.Port;
        }
        public override void TakeInput()
        {
            Console.WriteLine("Enter Output Directory : ");
            this.mongoDumpCommand.OutputDirectory = Console.ReadLine();
            if (!Directory.Exists(this.mongoDumpCommand.OutputDirectory))
            {
                try
                {
                    Directory.CreateDirectory(this.mongoDumpCommand.OutputDirectory); // i dont want it
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The output directory neither exists nor can be created");
                    throw ex;// codesmell once you catch you can not throw it :|
                }
            }

            Console.WriteLine("Enter Database Name : ");
            this.mongoDumpCommand.DatabaseName = Console.ReadLine();

            Console.WriteLine("Enter Collection Name : ");
            this.mongoDumpCommand.CollectionName = Console.ReadLine();
        }

        public override void BuildTask()
        {
            //throw new NotImplementedException();
        }

        public override void PeroformTask()
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Program Files\MongoDB\Server\3.2\bin\mongodump.exe";
            string cmd = this.mongoDumpCommand.BuildCommand();
            process.StartInfo.Arguments = this.mongoDumpCommand.BuildCommand();//string.Format("--host {0} --port {1} --out {2}", this.mongoDumpCommand.Host, this.mongoDumpCommand.Port, this.mongoDumpCommand.OutputDirectory);//\"E:\\Mogno_back_up_for_hamim_vai2\"
            //process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            process.Start();
            process.WaitForExit();// Waits here for the process to exit.
        }

        public override void ProduceOutput()
        {
            Console.WriteLine("Your dump has been taken in directory = {0}", this.mongoDumpCommand.OutputDirectory);
            //throw new NotImplementedException();
        }
    }
}
