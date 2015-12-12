using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BadServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
//http://stackoverflow.com/questions/21563940/how-to-connect-to-localdb-in-visual-studio-server-explorer