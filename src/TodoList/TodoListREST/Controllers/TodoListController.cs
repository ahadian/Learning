using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoListModel;

namespace TodoListREST.Controllers
{
    public class TodoListController : ApiController
    {
        public ResponseModel Get()
        {
            try
            {
                TodoListManager mgr = new TodoListManager();
                return new ResponseModel(mgr.Get());
            }
            catch (Exception e)
            {
                return new ResponseModel(null,false,e.Message);
            }      
        }

        public ResponseModel Post(TodoListTable newTask)
        {
            try
            {
                TodoListManager mgr = new TodoListManager();
                mgr.Add(newTask);
                return new ResponseModel();
            }
            catch (Exception e)
            {
                return new ResponseModel(null, false, e.Message);
            }   
        }

        public ResponseModel Put(TodoListTable newTask)
        {
            try
            {
                TodoListManager mgr = new TodoListManager();
                mgr.Update(newTask);
                return new ResponseModel();
            }
            catch (Exception e)
            {
                return new ResponseModel(null, false, e.Message);
            }
        }
        public ResponseModel Delete(int id)
        {
            try
            {
                TodoListManager mgr = new TodoListManager();
                mgr.Delete(id);
                return new ResponseModel();
            }
            catch (Exception e)
            {
                return new ResponseModel(null, false, e.Message);
            }
        }

    }
}
