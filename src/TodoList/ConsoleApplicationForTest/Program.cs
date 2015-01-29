using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListModel;

namespace ConsoleApplicationForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TodoListManager mgr = new TodoListManager();
            List<TodoListTable> x = mgr.Get();
        }
    }
}
