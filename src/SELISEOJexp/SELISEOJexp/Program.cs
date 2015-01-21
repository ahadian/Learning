using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SELISEOJexp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //string com = "/c " + @"D:\SeliseOJexp\b.bat";
                //string com2 = "/c " + @"D:\SeliseOJexp\in.txt";
                //System.Diagnostics.Process.Start("cmd.exe",com2);

                Process p = new Process();

                p.StartInfo.FileName = "cmd.exe";

                p.StartInfo.Arguments = @"/C D:\SeliseOJexp\b.bat";
                p.StartInfo.WorkingDirectory = @"D:\SeliseOJexp\";
                p.StartInfo.Verb = "runas";

                p.Start();

                //p.WaitForExit();
            }
            catch (Exception e)
            {
                string msg = e.Message;
            }
        }
    }
}
