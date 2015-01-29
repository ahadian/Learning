using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoListREST
{
    public class ResponseModel
    {
        public ResponseModel(object data = null, bool isSuccess = true, string message = "Success")
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }


        public bool IsSuccess { get; private set; }

        public object Data { get; private set; }

        public string Message { get; private set; }
    }
}