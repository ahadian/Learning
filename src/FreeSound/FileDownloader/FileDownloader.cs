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
            int logIdx = 0;
            Console.WriteLine("Program started to run...");
            while (true)
            {
                if (songDownloaded % 100 == 0)
                {
                    //logIdx++;
                    //FileStream ostrm;
                    //StreamWriter writer = null;
                    //TextWriter oldOut = Console.Out;
                    //try
                    //{
                    //    ostrm = new FileStream(string.Format("./FileDownloaderLog/Log4Job{0}.txt", logIdx), FileMode.OpenOrCreate, FileAccess.Write);
                    //    writer = new StreamWriter(ostrm);
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine("Cannot open Redirect.txt for writing");
                    //    Console.WriteLine(e.Message);
                    //}
                    //Console.SetOut(writer);
                }
                if (ConfigurationSettings.AppSettings["DebugMode"].Equals("true",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    debugMode = true;
                }
                var sound = new DataContext().GetNextSoundToDownload();
                Console.WriteLine("Attempting to download file ... << {0} >>", JsonConvert.SerializeObject(sound));
                if (sound != null)
                {
                    try
                    {
                        string fileDirectory = ConfigurationSettings.AppSettings["LocalDirectory"];
                        try
                        {
                            if (!Directory.Exists(fileDirectory)) Directory.CreateDirectory(fileDirectory);
                        }
                        catch (Exception ex)
                        {
                            while (ex != null)
                            {
                                Console.WriteLine("Error Occured while creating directory...{0}", JsonConvert.SerializeObject(ex));
                                ex = ex.InnerException;
                            }
                            continue;
                        }

                        string filePath = string.Format(@"{0}\{1}", fileDirectory, sound.id);
                        Console.WriteLine("The file is going to to be saved in path = {0}", filePath);
                        RestClient<DownloadRequest> restClient = new RestClient<DownloadRequest>(
                        HttpMethod.Get,
                        String.Empty,
                        string.Format(ConfigurationSettings.AppSettings["DownloadBaseUrl"], sound.id),
                        new DownloadRequest(),
                        MediaTypes.ApplicationXUrlEncoded);
                        HttpRequestMessage getData = restClient.CreateHttpRequest();
                        Console.WriteLine("Download uri...{0}", JsonConvert.SerializeObject(getData.RequestUri));
                        HttpClient client = new HttpClient()
                        {
                            Timeout = new TimeSpan(7, 0, 0, 0)
                        };
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authentication.idendity.access_token);
                        var response = client.GetAsync(getData.RequestUri).Result;
                        //var response = client.SendAsync(getData).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            using (Stream contentStream = response.Content.ReadAsStreamAsync().Result)
                            {
                                var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);
                                contentStream.CopyTo(stream);
                                stream.Close();
                                new DataContext().MarkSoundAsDownloaded(sound);
                                Console.WriteLine("Song {0} marked as downloaded", sound.id);
                            }
                        }
                        songDownloaded++;
                        Console.WriteLine("Song {0} successfullyFinishedDownloading in path...{1}", sound.id, filePath);
                        if (songDownloaded % 500 == 0)
                        {
                            Console.WriteLine("Attempting token exchange with old token = {0}", JsonConvert.SerializeObject(Authentication.idendity));
                            Authentication.IssueNewToken();
                            Console.WriteLine("New token Issued for songDownloaded = {0} , New token is = {1}", songDownloaded, JsonConvert.SerializeObject(Authentication.idendity));
                        }
                        if (debugMode) return;
                        int milliseconds = 5000;
                        //Thread.Sleep(milliseconds);
                    }
                    catch (Exception ex)
                    {
                        while (ex != null)
                        {
                            Console.WriteLine("Other Exception{0}", JsonConvert.SerializeObject(ex));
                            ex = ex.InnerException;
                        }
                    }

                }
                Console.WriteLine("Fetching finsihed for sound = << {0} >>", JsonConvert.SerializeObject(sound));
            }
        }
    }
}

