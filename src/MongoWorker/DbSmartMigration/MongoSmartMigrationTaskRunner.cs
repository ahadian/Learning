using Infrastructure;

namespace DbSmartMigration
{

    public class MongoSmartMigrationTaskRunner<T> : IMongoTaskRunner<T> where T : IMongoTask
    {
        public void Runtask(T mongoTask)
        {
            mongoTask.TakeInput();
            mongoTask.PeroformTask();
            mongoTask.ProduceOutput();
        }
    }
}
