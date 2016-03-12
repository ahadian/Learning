using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DateRnD.Controllers
{
    public class Data
    {
        public DateTime Date { get; set; }
    }
    public class ServerController : ApiController
    {
        // GET: api/Server
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Server/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Server
        public void Post(Data data)
        {
            /*
             Use this script to prepare date data 
             http://www.w3schools.com/jsref/jsref_toisostring.asp
             var d = new Date();
             var n = d.toISOString();
             {
                "Date":"2016-03-10T15:42:19.416Z"
             }
             */
        }

        // PUT: api/Server/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Server/5
        public void Delete(int id)
        {
        }
    }
}
