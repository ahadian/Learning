using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IMongoTaskRunner<T> where T : IMongoTask
    {
        void Runtask(T mongoTask);
    }
}
