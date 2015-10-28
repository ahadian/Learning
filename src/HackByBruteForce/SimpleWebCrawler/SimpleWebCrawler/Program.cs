using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleWebCrawler
{

    class Program
    {
        private static System.Timers.Timer aTimer;

        public static string GetUrl(string url)
        {
            
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string data = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                    return data;
                }
            }
            catch (Exception e)
            {

            }
            return String.Empty;
        }
        static void Main(string[] args)
        {
            const string chromePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            var url = Console.ReadLine();
            string data = GetUrl(url);
            aTimer = new System.Timers.Timer(10000);

        // Hook up the Elapsed event for the timer.
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

        // Set the Interval to 2 seconds (2000 milliseconds).
        aTimer.Interval = 5000;
        aTimer.Enabled = true;

        Console.WriteLine("Press the Enter key to exit the program.");
        Console.ReadLine();            
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            ConfigurationManager.RefreshSection("appSettings");
            SendMail();

        }

        private static void SendMail()
        {
            var fromAddress = new MailAddress("lesssecure.bd@gmail.com", "Najim");
            var toAddress = new MailAddress("najim.ju@gmail.com", "Najim");
            const string fromPassword = "Abracadabra";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            };
            smtp.UseDefaultCredentials = false;

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
