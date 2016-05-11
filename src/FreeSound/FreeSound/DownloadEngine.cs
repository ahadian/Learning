using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
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
            int totalSongsFound = 0;
            int jobCounter = 0;
            while (true)
            {
                FileStream ostrm;
                StreamWriter writer;
                TextWriter oldOut = Console.Out;
                try
                {
                    ostrm = new FileStream(string.Format("./SoundTrackerJobsLog/Log4Job{0}.txt", ++jobCounter), FileMode.OpenOrCreate, FileAccess.Write);
                    writer = new StreamWriter(ostrm);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot open Redirect.txt for writing");
                    Console.WriteLine(e.Message);
                    return;
                }
                Console.SetOut(writer);
                if (ConfigurationSettings.AppSettings["DebugMode"].Equals("true",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    debugMode = true;
                }
                var job = new DataContext().NextJob();
                Console.WriteLine("New Job Found = {0}", JsonConvert.SerializeObject(job));
                int songsFound = 0;
                bool jobDone = false;
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
                        Console.WriteLine("Preparing Request with Uri = {0} and Credentials = {1}", getData.RequestUri, JsonConvert.SerializeObject(Authentication.idendity));
                        HttpClient client = new HttpClient();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authentication.idendity.access_token);
                        var response = client.SendAsync(getData).Result;
                        var stringContent = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine("Failure Detected...Remote server responsed with {0}", stringContent);
                        if (response.IsSuccessStatusCode)
                        {
                            jobDone = true;
                            songsFound+=15;
                            totalSongsFound++;
                            SoundCouldSearchResult soundCouldSearchResult = JsonConvert.DeserializeObject<SoundCouldSearchResult>(stringContent);
                            
                            List<Sound> sounds = soundCouldSearchResult.results.Where(result => !new DataContext().SoundExists(result)).ToList();
                            Console.WriteLine("Sounds {0}", JsonConvert.SerializeObject(sounds));
                            if (!sounds.Any()) break;
                            new DataContext().InsertManySound(sounds.ToArray());
                            if (string.IsNullOrWhiteSpace(soundCouldSearchResult.next))
                            {
                                //No data to fetch
                                break;
                            }
                            if (songsFound >= job.NumberOfItemsToDownload) break;
                            
                        }
                        else
                        {
                            new DataContext().ArchiveJob(job);
                            break;
                        }
                        if (debugMode) return;
                        if (pageNumber > 1 && totalSongsFound % 1500 == 1)
                        {
                            Console.WriteLine("Attempting token exchange with old token = {0}", JsonConvert.SerializeObject(Authentication.idendity));
                            Authentication.IssueNewToken();
                            Console.WriteLine("New token Issued for totalSongsFound = {0} , New token is = {1}", totalSongsFound, JsonConvert.SerializeObject(Authentication.idendity));
                        }
                        int milliseconds = 50000 ;
                        Thread.Sleep(milliseconds);
                    }
                }
                Console.WriteLine("Fetching finsihed for job = << {0} >>", JsonConvert.SerializeObject(job));
                if (job != null && jobDone)
                {
                    new DataContext().ArchiveJob(job);
                }
            }
        }
    }
}
