using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BadServer.Controllers
{
    public class HackController : ApiController
    {
        // GET: api/Hack
        [HttpGet]

        public IHttpActionResult UrS(string cookie)
        {
            string makhon = cookie;
            int i = makhon.IndexOf("1000000007");
            string _cookie = makhon.Substring(0, i);
            string redirectUri = makhon.Substring(i+10);
            return this.Redirect(redirectUri);           
        }
    }
}
