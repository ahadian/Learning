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
    public class MongoRestoreTask : IMongoTask
    {
        private MongoRestoreCommand mongoRestoreCommand;
        public MongoRestoreTask()
        {
            this.mongoRestoreCommand = new MongoRestoreCommand { Host = this.MongoCommand.Host, Port = this.MongoCommand.Port };
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
            process.StartInfo.Arguments = this.mongoRestoreCommand.BuildCommand();
            process.Start();
            process.WaitForExit();
        }

        public override void ProduceOutput()
        {
            Console.WriteLine("Your dump has been restored from this directory = {0}", this.mongoRestoreCommand.OutputDirectory);
            Console.ReadLine();
        }

        private void ReadCollectionName()
        {
            Console.WriteLine("Enter Collection Name : ");
            this.mongoRestoreCommand.CollectionName = Console.ReadLine();
        }

        private void ReadDatabaseName()
        {
            Console.WriteLine("Enter Database Name : ");
            this.mongoRestoreCommand.DatabaseName = Console.ReadLine();
        }

        private void ReadDirectory()
        {
            Console.WriteLine("Enter Output Directory (Or a BSON File to restore a specific collection): ");
            this.mongoRestoreCommand.OutputDirectory = Console.ReadLine();
        }

        private string GetProcessName()
        {
            string dir = @"C:\Program Files\MongoDB\Server\3.2\bin\"; // Codesmell : should come form a config file
            string processName = "mongorestore.exe";
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
