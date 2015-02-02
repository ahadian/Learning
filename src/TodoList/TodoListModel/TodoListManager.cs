using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListModel
{
    public class TodoListManager
    {
        private TodoListDbEntities Db = null;

        public TodoListManager()
        {
            Db = new TodoListDbEntities();
        }

        public List<TodoListTable> Get()
        {
            return Db.TodoListTables.ToList();
        }
        public void Add(TodoListTable newTask)
        {
            DbSet<TodoListTable> myDb = Db.TodoListTables;
            myDb.Add(newTask);
            Db.SaveChanges();
        }
        public void Delete(int id)
        {
            TodoListTable s = Db.TodoListTables.FirstOrDefault(mytask => mytask.Id == id);
            if (s != null)
            {
                Db.TodoListTables.Remove(s);
            }
            Db.SaveChanges();
        }
        public void Update(TodoListTable newTask)
        {
            Db.TodoListTables.Attach(newTask);
            Db.Entry(newTask).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
