using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MarkedText.Controllers
{
    public class RequestModel
    {
        public string Value { get; set; }
    }
    public class SaveResponse
    {
        public string  Message { get; set; }
        public string Text { get; set; }
    }
    public class DictionaryController : ApiController
    {
        // GET: api/Dictionary
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Dictionary/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dictionary
        public HttpResponseMessage Post([FromBody]RequestModel request)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"H:\WriteLines2.doc", true))
            {
                file.WriteLine(request.Value);
                file.Close();
            }
            return Request.CreateResponse<SaveResponse>(HttpStatusCode.Accepted,new SaveResponse()
            {
                Message = "Success",
                Text = request.Value
            });
        }

        // PUT: api/Dictionary/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Dictionary/5
        public void Delete(int id)
        {
        }
    }
}
