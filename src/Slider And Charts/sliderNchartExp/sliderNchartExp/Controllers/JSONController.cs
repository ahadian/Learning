using System;
using System.Collections.Generic;
using System.IO;
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
            DateTime dt = new DateTime(2015, 6, 24,0, 0, 0).ToUniversalTime();
            DateTime dt2 = new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime();
            var xxx = dt.Ticks;
            var xyz = dt.Ticks - dt2.Ticks;
            string text = System.IO.File.ReadAllText(@"E:\outfile.txt");
            List<Population> populationList = JsonConvert.DeserializeObject<List<Population>>(text);
            return populationList.AsQueryable();
        }

        // GET: api/JSON/5
        public List<List<long>> GetTest(int id)
        {
            List<List<long>> response = new List<List<long>>();
            string text = System.IO.File.ReadAllText(@"E:\outfile.txt");
            List<Population> populationList = JsonConvert.DeserializeObject<List<Population>>(text);
            Dictionary<long,int> dic  =new Dictionary<long, int>();
            List<DateTime> dtList = new List<DateTime>();
            foreach (var p in populationList)
            {
                dtList.Add(p.Date);
                int year = p.Date.Year;
                int month = p.Date.Month;
                DateTime dt = new DateTime(year, month, 1, 0, 0, 0).ToUniversalTime();
                long tickCount = dt.Ticks;
                long tickCountAfter1970 = (tickCount - 621355968000000000);
                long jScriptTimespan = (tickCountAfter1970 / 10000);
                if (dic.ContainsKey(jScriptTimespan)) dic[jScriptTimespan]++;
                else dic.Add(jScriptTimespan,1);
            }
            dtList.Sort();
            TextWriter tw = new StreamWriter(@"E:\dates.txt");
            foreach (var x in dtList)tw.WriteLine(x.ToString());
            tw.Close();

            foreach (var pair in dic)
            {
                response.Add(new List<long>(){pair.Key,pair.Value});
            }
            return response;
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
