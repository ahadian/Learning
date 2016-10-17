using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbBackUp;
using DbSmartMigration;
using Infrastructure;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select an option : ");
            Console.WriteLine("1. Dump");
            Console.WriteLine("2. Restore");
            Console.WriteLine("3. Create a new Tenant");
            Console.WriteLine("4. Run Smart Migration");
            IMongoTask mongoTask;
            IMongoTaskRunner<IMongoTask> mongoTaskRunner;
            string commnad = Console.ReadLine();
            if ("1".Equals(commnad))
            {
                mongoTask = new MongoDumpTask();
                mongoTaskRunner = new MongoDumpTaskRunner<IMongoTask>();
                mongoTaskRunner.Runtask(mongoTask);
            }
            else if ("2".Equals(commnad))
            {
                mongoTask = new MongoRestoreTask();
                mongoTaskRunner = new MongoRestoreTaskRunner<IMongoTask>();
                mongoTaskRunner.Runtask(mongoTask);
            }
            else if ("3".Equals(commnad))
            {
                new ConsoleRun().RunForestRun();
            }
            else if ("4".Equals(commnad))
            {
                mongoTask = new MongoSmartMigrationTask();
                mongoTaskRunner = new MongoSmartMigrationTaskRunner<IMongoTask>();
                mongoTaskRunner.Runtask(mongoTask);
            }
            else
            {
                Console.WriteLine("Invalid Option....");
            }
        }
    }
}