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
            this.mongoDumpCommand = new MongoDumpCommand {Host = this.MongoCommand.Host, Port = this.MongoCommand.Port};
        }
        public override void TakeInput()
        {
            this.ReadDirectory();
            this.ReadDatabaseName();
            this.ReadCollectionName();
        }

        public override void PeroformTask()
        {
            Process process = new Process();
            process.StartInfo.FileName = this.GetProcessName();
            process.StartInfo.Arguments = this.mongoDumpCommand.BuildCommand();
            //process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            process.Start();
            process.WaitForExit();
        }

        public override void ProduceOutput()
        {
            Console.WriteLine("Your dump has been taken in directory = {0}", this.mongoDumpCommand.OutputDirectory);
            Console.ReadLine();
        }

        private void ReadCollectionName()
        {
            Console.WriteLine("Enter Collection Name : ");
            this.mongoDumpCommand.CollectionName = Console.ReadLine();
        }

        private void ReadDatabaseName()
        {
            Console.WriteLine("Enter Database Name : ");
            this.mongoDumpCommand.DatabaseName = Console.ReadLine();
        }

        private void ReadDirectory()
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
        }

        private string GetProcessName()
        {
            string dir = @"C:\Program Files\MongoDB\Server\3.2\bin\"; // Codesmell : should come form a config file
            string processName = "mongodump.exe";
            string fileName = string.Format(@"{0}{1}", dir, processName);
            if (!File.Exists(fileName))
            {
                Console.WriteLine("{0} not found in = {1}.", processName, dir);
                throw new Exception();
            }
            return fileName;
        }
    }
}
