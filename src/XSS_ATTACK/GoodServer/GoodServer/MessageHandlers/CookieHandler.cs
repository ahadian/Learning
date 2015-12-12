using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GoodServer.MessageHandlers
{
    public class CookieHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var c = HttpContext.Current.Response.Cookies;
            var response = await base.SendAsync(request, cancellationToken);
            var cookie = new HttpCookie("GoodServerCookie", "this cookie came from good server");
            //cookie.Domain = "127.0.0.1";
            cookie.Expires = DateTime.UtcNow.AddMinutes(60);
            HttpContext.Current.Response.Cookies.Set(cookie);
            return response;
        }
    }
}