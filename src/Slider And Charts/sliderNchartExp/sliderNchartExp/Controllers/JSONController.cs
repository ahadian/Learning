using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Selise.Cms.Service.Models;

namespace sliderNchartExp.Controllers
{
    public class JSONController : ApiController
    {
        // GET: api/JSON
        public IQueryable<Population> Get()
        {
            string text = System.IO.File.ReadAllText(@"E:\outfile.txt");
            List<Population> populationList = JsonConvert.DeserializeObject<List<Population>>(text);
            return populationList.AsQueryable();
        }

        // GET: api/JSON/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JSON
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/JSON/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JSON/5
        public void Delete(int id)
        {
        }
    }
}
