using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Newtonsoft.Json;
using ReflectionTest;
using ReflectionTest.DataDefination.Core.PrimaryEntities;
using WebApplication1.lib;

namespace WebApplication1.Controllers
{
    public class FormatRequest
    {
        public string EntityName { get; set; }

        public string JsonString { get; set; }

    }
    public class FormatterController : ApiController
    {
        [CamelCaseFilter]
        public HttpResponseMessage CamelCase([FromBody]FormatRequest req)
        {
            try
            {
                var ret = IsPascalCase(req.JsonString);
                if (ret == true)
                {
                    var finalResult = JsonConvert.DeserializeObject(req.JsonString);
                    return this.Request.CreateResponse(HttpStatusCode.OK, finalResult);
                }
                else
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "The JSON you provided does not qualify Pascal Case Requirement!");
                }
                
            }
            catch (Exception e)
            {
                
                throw;
            }
        }

        public static string Resolve(string jsonString)
        {
            var result = jsonString.ToArray();
            for (int i = 0; i < result.Count(); i++)
            {
                if (result[i] == ':')
                {
                    int idx = i-1;
                    int dcCount = 0;
                    while (true)
                    {
                        if (result[idx] == '"') dcCount++;
                        if (dcCount == 2) break;
                        idx--;
                    }
                    string dbg = jsonString.Substring(idx, i - idx);
                    if(char.IsLower(result[idx + 1]))throw new Exception("Please Follow Pascal Case Convension");
                    //result[idx + 1] = char.ToUpper(result[idx + 1]);
                }
            }
            var res = new string(result);
            return res;
            return null;

        }

        public static bool IsPascalCase(string jsonString)
        {
            var result = jsonString.ToArray();
            for (int i = 0; i < result.Count(); i++)
            {
                if (result[i] == ':')
                {
                    int idx = i - 1;
                    int dcCount = 0;
                    while (true)
                    {
                        if (result[idx] == '"') dcCount++;
                        if (dcCount == 2) break;
                        idx--;
                    }
                    string dbg = jsonString.Substring(idx, i - idx);
                    if (char.IsLower(result[idx + 1])) return false;
                    //result[idx + 1] = char.ToUpper(result[idx + 1]);
                }
            }
            return true;
        }
    }
}
