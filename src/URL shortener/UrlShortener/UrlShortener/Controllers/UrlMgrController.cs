using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;


namespace UrlShortener.Controllers
{
    public class Response
    {
        public string ResponseMessage { get; set; }
        public string FullUrl { get; set; }
        public string EncodedUrl { get; set; }
    }

    public sealed class Engine
    {
        private static Engine myEngine = null;
        public static Queue<string> Keys;
        public static Dictionary<string, string> LookUp_Url_Key;
        public static Dictionary<string, string> LookUp_Key_Url;

        public static void Generate(int pos, string s)
        {
            if (pos == 5) return;
            if (!string.IsNullOrEmpty(s))
            {
                Keys.Enqueue(s.ToString());
            }
            for (char i = 'a'; i <= 'z'; i++)
            {
                string p = s + i.ToString();
                Generate(pos + 1, p);
            }
        }
        private Engine()
        {
            Keys = new Queue<string>(1000000);
            LookUp_Url_Key = new Dictionary<string, string>();
            LookUp_Key_Url = new Dictionary<string, string>();
            Generate(0, "");
        }

        public static Engine TheEngine
        {
            get
            {
                if (myEngine == null)
                {
                    myEngine = new Engine();
                }
                return myEngine;
            }
        }

        public string Encode(string Url)
        {
            if (LookUp_Url_Key.ContainsKey(Url)) return LookUp_Url_Key[Url];
            LookUp_Url_Key[Url] = Keys.Peek();
            LookUp_Key_Url[Keys.Peek()] = Url;
            Keys.Dequeue();
            return LookUp_Url_Key[Url];
        }
        public string Decode(string _key)
        {
            if (!LookUp_Key_Url.ContainsKey(_key)) return "The shorten Url is Invalid!";
            return LookUp_Key_Url[_key];
        }

    }
    public class UrlMgrController : ApiController
    {
        private string baseUrl = "http://localhost:38252/api/UrlMgr/";
        public UrlMgrController()
        {
            string conString = @"Data Source=STONEHEART\STONEHEART;" + "Trusted_Connection=yes;" + "Integrated Security=True;" + "Initial Catalog=UrlShortener;" + "database=UrlShortener; " + "connection timeout=5";
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();
                var x = conn.State == ConnectionState.Open;


            }
        }


        [HttpGet]
        public Response GetEncodedUrl(string fullUrl)
        {
            return new Response()
            {
                EncodedUrl = baseUrl + "GetFullUrl?encodedUrl=" + Engine.TheEngine.Encode(fullUrl),
                FullUrl = fullUrl,
                ResponseMessage = "success"
            };
        }
        public Response GetFullUrl(string encodedUrl)
        {
            return new Response()
            {
                EncodedUrl = encodedUrl,
                FullUrl = Engine.TheEngine.Decode(encodedUrl),
                ResponseMessage = "success"
            };
        }
    }
}
/*
 http://localhost:38252/api/UrlMgr/GetEncodedUrl?fullUrl=www.facebook.com
 * Total Capacity = 938265 
 */
