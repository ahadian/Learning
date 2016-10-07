﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbBackUp;
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
            IMongoTask mongoTask;
            IMongoTaskRunner<IMongoTask> mongoTaskRunner;
            string commnad = Console.ReadLine();
            if ("1".Equals(commnad))
            {
                mongoTask = new MongoDumpTask();
                mongoTaskRunner = new MongoDumpTaskRunner<IMongoTask>();
                mongoTaskRunner.Runtask(mongoTask);
            }
        }
    }
}
