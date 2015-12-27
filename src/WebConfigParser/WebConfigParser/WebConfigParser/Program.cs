using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebConfigParser
{
    class Program
    {
        private static void Main(string[] args)
        {
            string inp;
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            List<string> makhons = new List<string>();
            while (true)
            {
                inp = Console.ReadLine();
                if (inp.Contains("123")) break;
                var tokens = inp.Split(' ');
                string key = null, value = null;
                foreach (var token in tokens)
                {
                    if (token.Contains("="))
                    {
                        var keyVal = token.Split('=');
                        if (keyVal[0].ToLower().Contains("key")) key = keyVal[1];
                        if (keyVal[0].ToLower().Contains("value")) value = keyVal[1];
                    }
                }
                if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value)) ;
                else
                {

                    string makhon = key + ":" + value;
                    if (dic.ContainsKey(key)) ;
                    else
                    {
                        makhons.Add(makhon);
                        //writer.WriteLine(makhon + ",");
                        dic.Add(key, true);
                    }

                }
            }
            makhons.Sort();
            using (StreamWriter writer = new StreamWriter(@"F:\Learning\src\WebConfigParser\WebConfigParser\result.txt", true))
            {

                foreach (var makhon in makhons)
                {
                    writer.WriteLine(makhon + ",");
                }
            }
        }
    }
}
