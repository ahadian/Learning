using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Common;
using Newtonsoft.Json;
using Selise.AppSuite.Common;


namespace FreeSound
{
    public class FileDownloader
    {
        public static void Work()
        {
            bool debugMode = false;
            Authentication.InitIdentity();
            int songDownloaded = 0;
            while (true)
            {
                if (ConfigurationSettings.AppSettings["DebugMode"].Equals("true",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    debugMode = true;
                }
                var sound = new DataContext().GetNextSoundToDownload();
                if (sound != null)
                {
                    while (true)
                    {
                        string fileDirectory = ConfigurationSettings.AppSettings["LocalDirectory"];
                        string tempLocalDirectory = ConfigurationSettings.AppSettings["TempLocalDirectory"];
                        if (!Directory.Exists(fileDirectory)) Directory.CreateDirectory(fileDirectory);
                        string filePath = string.Format(@"{0}\{1}", fileDirectory, sound.id);

                        RestClient<DownloadRequest> restClient = new RestClient<DownloadRequest>(
                        HttpMethod.Get,
                        String.Empty,
                        string.Format(ConfigurationSettings.AppSettings["DownloadBaseUrl"], sound.id),
                        new DownloadRequest(),
                        MediaTypes.ApplicationXUrlEncoded);

                        HttpRequestMessage getData = restClient.CreateHttpRequest();
                        HttpClient client = new HttpClient();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authentication.idendity.access_token);
                        var response = client.SendAsync(getData).Result;
                         
                        if (response.IsSuccessStatusCode)
                        {
                            using (Stream contentStream = response.Content.ReadAsStreamAsync().Result)
                            {
                                var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
                                contentStream.CopyToAsync(stream);
                                new DataContext().MarkSoundAsDownloaded(sound);
                            }
                        }
                        songDownloaded++;
                        if (songDownloaded%89 == 0)
                        {
                            
                        }
                        if (debugMode) return;
                        int milliseconds = 50000;
                        Thread.Sleep(milliseconds);
                    }
                }
                Console.WriteLine("Fetching finsihed for sound = << {0} >>", sound);
                //if (sound != null)
                //{
                //    new DataContext().ArchiveJob(sound);
                //}
            }
        }
    }
}

