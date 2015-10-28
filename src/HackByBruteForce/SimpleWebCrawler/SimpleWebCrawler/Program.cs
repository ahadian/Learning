// /*
//  Copyright (C) Secure Link Services AG. <info@selise.ch>
//  This file is part of SELISE ECAP (Enterprise Cloud Application Platform)
//  Any code from SELISE ECAP can not be copied, distributed, reused, published without explicit written and signed permission of management of Secure Link Services AG.
// */

using System.Diagnostics.CodeAnalysis;

namespace HackByBruteForce
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Timers;

    internal class Program
    {
        private static Timer aTimer;

        private static string Destination, Name, Text1, Text2, Url, TimeInterval;

        public static string GetUrl(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    var data = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                    return data;
                }
            }
            catch (Exception e)
            {
            }

            return string.Empty;
        }

        private static void Main(string[] args)
        {
            Url = ConfigurationManager.AppSettings["Url"];
            Text1 = ConfigurationManager.AppSettings["KeyWord1"];
            Text2 = ConfigurationManager.AppSettings["KeyWord2"];
            Destination = ConfigurationManager.AppSettings["Destination"];
            Name = ConfigurationManager.AppSettings["Name"];
            TimeInterval = ConfigurationManager.AppSettings["Interval_SECOND"];


            aTimer = new Timer(10000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Interval = int.Parse(TimeInterval);
            aTimer.Enabled = true;
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }

        [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1503:CurlyBracketsMustNotBeOmitted", Justification = "Reviewed. Suppression is OK here."),SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1408:ConditionalExpressionsMustDeclarePrecedence", Justification = "Reviewed. Suppression is OK here.")]
        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            var data = GetUrl(Url);
            if (data != null)
            {
                int idx1 = data.IndexOf(Text1, StringComparison.InvariantCultureIgnoreCase);
                int idx2 = data.IndexOf(Text2, StringComparison.InvariantCultureIgnoreCase);
                bool isActive = (idx1 == -1) || (idx2 == -1);
                if (isActive)
                {
                    SendMail();
                }
            }
        }

        private static void SendMail()
        {
            var fromAddress = new MailAddress("lesssecure.bd@gmail.com", "Najim");
            var toAddress = new MailAddress(Destination, Name);
            const string fromPassword = "Abracadabra";
            const string subject = "Activated!!!";
            const string body = "The Link is On!!!Hurry Up!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

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