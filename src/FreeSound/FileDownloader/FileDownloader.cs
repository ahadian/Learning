using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Common;
using log4net;
using Newtonsoft.Json;
using Selise.AppSuite.Common;


namespace FreeSound
{
    public class FileDownloader
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
                        bool downloadSuccess = DownloadFile(getData.RequestUri, Authentication.idendity.access_token, fileDirectory, sound.id.ToString());
                        if (downloadSuccess)
                        {
                            songDownloaded++;
                            Console.WriteLine("Song {0} successfullyFinishedDownloading in path...{1}", sound.id, filePath);
                            new DataContext().MarkSoundAsDownloaded(sound);
                        }

                        if (songDownloaded % 500 == 0)
                        {
                            Console.WriteLine("Attempting token exchange with old token = {0}", JsonConvert.SerializeObject(Authentication.idendity));
                            //Authentication.IssueNewToken();
                            Console.WriteLine("New token Issued for songDownloaded = {0} , New token is = {1}", songDownloaded, JsonConvert.SerializeObject(Authentication.idendity));
                        }
                        if (debugMode) return;
                        int milliseconds = 5000;
                        Thread.Sleep(milliseconds);
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

        private static bool DownloadFile(Uri requestUri, string authenticationHeaderValue, string workingPath, string id)
        {
            using (var myWebClient = new WebClient())
            {
                myWebClient.Headers.Add("Authorization", "Bearer " + authenticationHeaderValue);
                Console.WriteLine("Downloading File = as Chunk{0}", requestUri);
                if (!Directory.Exists(workingPath))
                {
                    try
                    {
                        Directory.CreateDirectory(workingPath);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Exception Occcured while creating directory...");
                        var ex = exception;
                        var level = 0;
                        while (ex != null)
                        {
                            Console.WriteLine(string.Format("Exception Message At Level = {0} => {1}", ++level, ex.Message));
                            ex = ex.InnerException;
                        }

                        Console.WriteLine("Exception = ", exception);
                    }
                }

                var temporaryFilePath = string.Format("{0}//{1}", workingPath, id);
                Console.WriteLine(string.Format("Temporary working path is ....{0}", temporaryFilePath));

                try
                {
                    using (Stream webStream = myWebClient.OpenRead(requestUri))
                    {
                        Console.WriteLine(string.Format("webStream OpenRead for URL is not null = {0}", webStream != null));
                        using (var fileStream = new FileStream(temporaryFilePath, FileMode.Create))
                        {
                            var buffer = new byte[32768];
                            int bytesRead;
                            long bytesReadComplete = 0;

                            var bytesTotal = System.Convert.ToInt64(myWebClient.ResponseHeaders["Content-Length"]);

                            var sw = Stopwatch.StartNew();
                            long oldTime = 0;
                            while ((bytesRead = webStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                bytesReadComplete += bytesRead;
                                fileStream.Write(buffer, 0, bytesRead);
                                var sb = new StringBuilder();
                                sb.AppendLine(string.Format("Progress: {0:0%}", (double)bytesReadComplete / bytesTotal));
                                sb.AppendLine(string.Format("Downloaded: {0:0,0} Bytes", bytesReadComplete));
                                sb.AppendLine(string.Format("Time Elapsed: {0:0,.00}s", sw.ElapsedMilliseconds));
                                sb.AppendLine(string.Format("Average Speed: {0:0,0} KB/s", sw.ElapsedMilliseconds > 0 ? bytesReadComplete / sw.ElapsedMilliseconds / 1.024 : 0));
                                if (sw.ElapsedMilliseconds - oldTime >= 5000)
                                {
                                    Console.WriteLine("DownloadFileInfo = {0}", sb);
                                    oldTime = sw.ElapsedMilliseconds;
                                }
                            }

                            sw.Stop();
                        }
                    }
                    Console.WriteLine("Download Succeeded...");
                    return true;
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Exception Occcured while creating directory...");
                    var ex = exception;
                    var level = 0;
                    while (ex != null)
                    {
                        Console.WriteLine(string.Format("Exception Message At Level = {0} => {1}", ++level, ex.Message));
                        ex = ex.InnerException;
                    }

                    Console.WriteLine("Exception = ", exception);
                }
                return false;

            }
        }
    }
}

