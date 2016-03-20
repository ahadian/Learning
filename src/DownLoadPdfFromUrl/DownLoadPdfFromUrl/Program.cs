using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DownLoadPdfFromUrl
{
    //public class CookieAwareWebClient : WebClient
    //{
    //    public CookieContainer CookieContainer { get; set; }
    //    public Uri Uri { get; set; }

    //    public CookieAwareWebClient()
    //        : this(new CookieContainer())
    //    {
    //    }

    //    public CookieAwareWebClient(CookieContainer cookies)
    //    {
    //        this.CookieContainer = cookies;
    //    }

    //    protected override WebRequest GetWebRequest(Uri address)
    //    {
    //        WebRequest request = base.GetWebRequest(address);
    //        if (request is HttpWebRequest)
    //        {
    //            (request as HttpWebRequest).CookieContainer = this.CookieContainer;
    //        }
    //        HttpWebRequest httpRequest = (HttpWebRequest)request;
    //        httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    //        return httpRequest;
    //    }

    //    protected override WebResponse GetWebResponse(WebRequest request)
    //    {
    //        WebResponse response = base.GetWebResponse(request);
    //        String setCookieHeader = response.Headers[HttpResponseHeader.SetCookie];

    //        if (setCookieHeader != null)
    //        {
    //            //do something if needed to parse out the cookie.
    //            if (setCookieHeader != null)
    //            {
    //                Cookie cookie = new Cookie(); //create cookie
    //                this.CookieContainer.Add(cookie);
    //            }
    //        }
    //        return response;
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            //CookieContainer cookieJar = new CookieContainer();
            //cookieJar.Add(new Cookie("PHPSESSID", "vrsjso8bcmfb5ja02klqihp8b6", "/", "www.lightoj.com"));
            //cookieJar.Add(new Cookie("myuseridlightoj", "4258", "/", "www.lightoj.com"));
            //cookieJar.Add(new Cookie("myusernamelightoj", "najim_ju", "/", "www.lightoj.com"));
            //cookieJar.Add(new Cookie("myusersidlightoj", "JDodlwkk5axW16o4EuB4hImIfJ2Z67FgIrTt6Zl3TmUipQow6l", "/", "www.lightoj.com"));
            //cookieJar.Add(new Cookie("myusertypelightoj", "normal", "/", "www.lightoj.com"));
            string baseUri = "http://www.lightoj.com/volume_showproblem.php?problem={0}&language=english&type=pdf";
            string directory = @"D:\LighOjOffLine\VOLUME_{0}.pdf";
            using (WebClient client = new WebClient())
            {
                for (int volume = 12; volume <= 14; volume++)
                {
                    string fileDirectory = string.Format(directory, volume);
                    if(!Directory.Exists(fileDirectory))Directory.CreateDirectory(fileDirectory);
                    
                    for (int problem = 0; problem < 100; problem++)
                    {
                        
                        //client.DownloadFile("http://www.irs.gov/pub/irs-pdf/fw4.pdf", @"D:\Temp.pdf");
                        int problemId = (volume*100) + problem;
                        string filePath = string.Format(@"{0}\{1}.pdf", fileDirectory, problemId);
                        string url = string.Format(baseUri, problemId);
                        client.DownloadFile(url, filePath);
                    }
                }
            }

        }
    }
}
