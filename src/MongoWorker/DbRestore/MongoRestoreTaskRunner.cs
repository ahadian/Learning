using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace DbBackUp
{

    public class MongoRestoreTaskRunner<T> : IMongoTaskRunner<T> where T : IMongoTask
    {
        public void Runtask(T mongoTask)
        {
            mongoTask.TakeInput();
            mongoTask.PeroformTask();
            mongoTask.ProduceOutput();
        }
    }
}
