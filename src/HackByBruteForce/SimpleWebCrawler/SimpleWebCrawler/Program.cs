﻿// /*
//  Copyright (C) Secure Link Services AG. <info@selise.ch>
//  This file is part of SELISE ECAP (Enterprise Cloud Application Platform)
//  Any code from SELISE ECAP can not be copied, distributed, reused, published without explicit written and signed permission of management of Secure Link Services AG.
// */

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

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

        private static string Destination, Name, Text1, Text2, Url, TimeInterval, LogFileDest;

        public static string GetUrl2(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    string result = client.DownloadString(url);
                    return result;
                }
            }
            catch (Exception e)
            {
            }

            return string.Empty;
        }

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
            LogFileDest = ConfigurationManager.AppSettings["LogFile"];

            string fileName = LogFileDest + "\\logFile" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture) + "__Test.txt";
            Write("This is Test Write....", 503);

            aTimer = new Timer(10000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Interval = int.Parse(TimeInterval);
            aTimer.Enabled = true;
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }

        [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1503:CurlyBracketsMustNotBeOmitted", Justification = "Reviewed. Suppression is OK here."), SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1408:ConditionalExpressionsMustDeclarePrecedence", Justification = "Reviewed. Suppression is OK here.")]
        private static async void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            var data = GetUrl(Url);

            bool stateData1 = false;
            bool stateData2 = false;
            if (data != null)
            {
                int idx1 = data.IndexOf(Text1, StringComparison.InvariantCultureIgnoreCase);
                int idx2 = data.IndexOf(Text2, StringComparison.InvariantCultureIgnoreCase);
                stateData1 = (idx1 == -1) || (idx2 == -1);
            }

            var data2 = GetUrl2(Url);
            if (data2 != null)
            {
                int idx1 = data2.IndexOf(Text1, StringComparison.InvariantCultureIgnoreCase);
                int idx2 = data2.IndexOf(Text2, StringComparison.InvariantCultureIgnoreCase);
                stateData2 = (idx1 == -1) || (idx2 == -1);
            }

            if (stateData1 && stateData2)
            {
                await Write(data, 200);
                SendMail(Text1, Text2, data);
            }
            else
            {
                await Write(data, 401);
            }
        }


        private static async Task Write(string data, int status)
        {
            string fileName = LogFileDest + "\\logFile" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture) + status + ".txt";
            using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                await sw.WriteLineAsync(data);

                sw.Close();
                fs.Close();
            }
        }
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }


        private static void SendMail(string text1, string text2, string data)
        {
            return;
            var fromAddress = new MailAddress("lesssecure.bd@gmail.com", "Najim");
            var toAddress = new MailAddress(Destination, Name);
            const string fromPassword = "abracadabra`business=121221321";
            const string subject = "Activated!!!";
            string body = string.Format("The link you provided is missing either Text{0} or Text{1} or both. The Html fetched from the server is sent to you as attachment for your kind review.", Text1, Text2);

            System.Net.Mail.Attachment att = Attachment.CreateAttachmentFromString(data, "abc.html");

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
                Body = body,
                Attachments = { att }
            })
            {
                smtp.Send(message);
            }
        }
    }
}