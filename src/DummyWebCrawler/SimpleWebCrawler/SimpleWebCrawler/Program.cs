using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebCrawler
{

    class Program
    {
        private const int EstimatedMaxUrlLength = 200;
        public static Dictionary<string, int> Freq = new Dictionary<string, int>();
        public static string GetUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
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
            string alDaily = "http://www.aldaily.com/";
            List<string> errorMessages = new List<string>();
            List<string> featuredNewsUrls = new List<string>();
            //Process.Start(chromePath, nextUrl);
            string data = GetUrl(alDaily);

            int len = data.Length;
            int i = 0;
            while ((i = data.IndexOf("more&nbsp", i, StringComparison.Ordinal)) != -1)
            {
                int startPos = Math.Max(0, i - EstimatedMaxUrlLength);
                string guessAncor = ParseAnchorTag(data.Substring(startPos, EstimatedMaxUrlLength));
                featuredNewsUrls.Add(guessAncor);
                i++;
            }

            for (i = 0; i < featuredNewsUrls.Count; i++)
            {
                WordFrequency(GetUrl(featuredNewsUrls[i]));
                //Process.Start(chromePath, featuredNewsUrls[i]);
                //Console.WriteLine("Visit following Url:\n" + featuredNewsUrls[i]);
                //string command = Console.ReadLine();
                //if("yes".IndexOf(command,StringComparison.InvariantCultureIgnoreCase)!=-1)Process.Start(chromePath, featuredNewsUrls[i]);
                
            }
        }

        private static void WordFrequency(string data)
        {
            int i = 0;
            while ((i = data.IndexOf("<p>", i, StringComparison.Ordinal)) != -1)
            {
                string cxx = data.Substring(i, 30);
                int endTag = data.IndexOf("</p>", i + 1, StringComparison.Ordinal);
                string paragraph = data.Substring(i+3, endTag - i );
                List<string> list = getWordList(paragraph);
                foreach (var word in list)
                {
                    if (Freq.ContainsKey(word))
                    {
                        Freq[word]++;
                    }
                    else Freq.Add(word,1);
                }
                i++;
            }
            WriteDictionary();
        }

        private static string ParseAnchorTag(string str)
        {
            int startTagIdx = str.IndexOf("<a");
            //string u = str.Substring(startTagIdx - 10, 10);
            int endTagIdx = str.IndexOf(">");

            while (endTagIdx != -1 && endTagIdx < startTagIdx)
            {
                endTagIdx = str.IndexOf(">", endTagIdx + 1);
            }
            if (startTagIdx == -1 || endTagIdx == -1) return string.Empty;
            string originalTag = str.Substring(startTagIdx, endTagIdx - startTagIdx + 1);
            int l = originalTag.IndexOf("\"");
            int r = originalTag.IndexOf("\"", l + 1);
            l++;
            r--;
            if (l == -1 || r == -1) return string.Empty;
            return originalTag.Substring(l, r - l + 1);
        }

        private static List<string> getWordList(string str)
        {
            return str.Split(new char[] {' ', '.', '?'}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private static void WriteDictionary()
        {
            var items = from pair in Freq
                        orderby pair.Value ascending
                        select pair;
            File.WriteAllLines(@"H:\Mydictionary.doc", items.Select(x => "[" + x.Key + "\t" + x.Value + "]").ToArray());
        }
    }
}
