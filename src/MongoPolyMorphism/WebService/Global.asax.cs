using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
var y = typeof(Repository.MongoDbDataContext).GetType().GetMethods().Where(x => x.Name == "GetCollection" && x.GetGenericArguments().Length==0).FirstOrDefault();