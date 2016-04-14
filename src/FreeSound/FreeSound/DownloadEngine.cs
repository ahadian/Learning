using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Selise.AppSuite.Common;


namespace FreeSound
{
    public class DownloadEngine
    {
        public static void Work()
        {
            int pageSize = 15, pageNumber = 0;
            bool debugMode = false;
            Authentication.InitIdentity();
            while (true)
            {
                if (ConfigurationSettings.AppSettings["DebugMode"].Equals("true",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    debugMode = true;
                }
                var job = new DataContext().NextJob();
                if (job != null && !string.IsNullOrEmpty(job.Tag))
                {
                    while (true)
                    {
                        RestClient<SearchRequest> restClient = new RestClient<SearchRequest>(
                        HttpMethod.Get,
                        String.Empty,
                        ConfigurationSettings.AppSettings["SearchBaseUrl"],
                        new SearchRequest() { page = ++pageNumber, query = job.Tag },
                        MediaTypes.ApplicationXUrlEncoded);

                        HttpRequestMessage getData = restClient.CreateHttpRequest();
                        HttpClient client = new HttpClient();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authentication.idendity.access_token);
                        var response = client.SendAsync(getData).Result;
                        var stringContent = response.Content.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode)
                        {
                            SoundCouldSearchResult soundCouldSearchResult = JsonConvert.DeserializeObject<SoundCouldSearchResult>(stringContent);
                            new DataContext().InsertManySound(soundCouldSearchResult.results);
                            if (string.IsNullOrWhiteSpace(soundCouldSearchResult.next))
                            {
                                //No data to fetch
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Failure Detected...Remote server responsed with {0}", stringContent);
                            break;
                        }
                        if (debugMode) return;
                        if (pageNumber > 1 && pageNumber % 87 == 1)
                        {
                            Authentication.IssueNewToken();
                        }
                        int milliseconds = 50000;
                        Thread.Sleep(milliseconds);
                    }
                }
                Console.WriteLine("Fetching finsihed for job = << {0} >>", job);
                if (job != null)
                {
                    new DataContext().ArchiveJob(job);
                }
            }
        }
    }
}
