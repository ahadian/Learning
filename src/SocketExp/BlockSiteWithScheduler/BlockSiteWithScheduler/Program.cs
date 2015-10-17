//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading.Tasks;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading;
//using System.Timers;
//using System.Security;
//using System.Security.Permissions;

//namespace BlockSiteWithScheduler
//{
//    static class Constants
//    {
//        public const int port = 0;
//        public const int buffer_size = 512;


//    }


//    public class communication
//    {
//        public int byteReceived;
//        public byte[] bb;

//        public void doCommunicate(Socket clientSocket, string client_addr)
//        {
//            clientSocket.Blocking = true;
//            bb = new byte[Constants.buffer_size];

//            //Console.WriteLine("***** Entered DoCommunicate *****");
//            while (clientSocket.Connected)
//            {
//                //Console.WriteLine("Entered While");
//                try
//                {
//                    //Console.WriteLine("Entered TRY");
//                    Console.WriteLine("Waiting to recieve Data from IP : client_addr");
//                    //int ReceivedDataLength = Client.Receive(ReceivedBytes, 0, ReceivedBytes.Length, SocketFlags.None);
//                    byteReceived = clientSocket.Receive(bb, 0, bb.Length, SocketFlags.None);
//                    //byteReceived = clientSocket.Receive(bb);
//                }
//                catch (SocketException e)
//                {
//                    Console.WriteLine("Error: Socket Exception.\n{0}\n{1}.", e.Message, e.ErrorCode);
//                    break;
//                }
//                catch (ArgumentNullException e)
//                {
//                    Console.WriteLine("Error : Argument Null Exception.\n{0}", e.Message);
//                    break;
//                }
//                catch (ObjectDisposedException e)
//                {
//                    Console.WriteLine("Error : Socket Disposed Exception Caught.\n{0}", e.Message);
//                    break;
//                }
//                catch (SecurityException e)
//                {
//                    Console.WriteLine("Error: Security Exception.\n{0}", e.Message);
//                    break;
//                }
//                //clientSocketglobal.Send(Encoding.Default.GetBytes("Hello Client"), SocketFlags.None);
//                Console.WriteLine("Received Byte count : {0}, from IP : {1}", byteReceived, client_addr);
//                // Do whatever you want to do with the data recieved. Parsing and storing etc.
//                Console.WriteLine(Encoding.UTF8.GetString(bb));
//            }
//            //Console.WriteLine("While Loop Exited");
//            Console.WriteLine("Socked and Class Object  Disposed");
//            clientSocket.Close();
//            clientSocket.Dispose();
//            GC.Collect();
//        }
//    }


//    public class Program
//    {
//        public static string LocalIPAddress()
//        {
//            IPHostEntry host;
//            string localIP = "";
//            host = Dns.GetHostEntry(Dns.GetHostName());
//            foreach (IPAddress ip in host.AddressList)
//            {
//                if (ip.AddressFamily == AddressFamily.InterNetwork)
//                {
//                    localIP = ip.ToString();
//                    break;
//                }
//            }
//            return localIP;
//            //return ip;
//        }

//        //    static void Main(string[] args)
//        //    {
//        //        IPEndPoint ipObj = new IPEndPoint(IPAddress.Parse(LocalIPAddress()), 0); //20487 is port. you can change it according to your wish
//        //        System.Net.IPAddress IP = IPAddress.Any;
//        //        int port = Constants.port;
//        //        TcpListener listnerObj = new TcpListener(IP, port);
//        //        listnerObj.Start();
//        //        string client_addr;
//        //        string[] client_addr_split;
//        //        string IP_string = LocalIPAddress();

//        //        Console.WriteLine("Server Started on {0}:{1}", IP_string, port);
//        //        while (true)
//        //        {
//        //            Console.WriteLine("================================");
//        //            Console.WriteLine("**    Waiting For Client     **");
//        //            Socket clientSocket = listnerObj.AcceptSocket(); // waiting for the client to connect


//        //            client_addr = clientSocket.RemoteEndPoint.ToString();
//        //            client_addr_split = client_addr.Split(':');
//        //            client_addr = client_addr_split[0];

//        //            Console.WriteLine("Client Connected {0}", client_addr);
//        //            ParameterizedThreadStart thread =
//        //                delegate { new communication().doCommunicate(clientSocket, client_addr); };
//        //            Thread th = new Thread(thread);
//        //            th.Start(); // start the thread here 
//        //        }

//        //        try
//        //        {
//        //            byte[] input = BitConverter.GetBytes(1);
//        //            byte[] buffer = new byte[4096];
//        //            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
//        //            s.Bind(new IPEndPoint(IPAddress.Parse("192.168.0.107"), 8080));
//        //            s.IOControl(IOControlCode.ReceiveAll, input, null);

//        //            int bytes = 0;
//        //            do
//        //            {
//        //                bytes = s.Receive(buffer);
//        //                if (bytes > 0)
//        //                {
//        //                    Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));
//        //                }
//        //            } while (bytes > 0);
//        //        }
//        //        catch (Exception ex)
//        //        {
//        //            Console.WriteLine(ex);
//        //        }
//        //    }
//    }
//}

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    private static bool isclosing = false;
    static DateTime st, fn;
    static double totalhours = 0;
    private static string path = @"C:\Windows\System32\drivers\etc";
    private static string file = "hosts";
    static string facebook = "www.facebook.com 127.0.0.1";
    static string youtube = "www.youtube.com 127.0.0.1 ";
    

    static void Main(string[] args)
    {
        
        

        SetConsoleCtrlHandler(new HandlerRoutine(ConsoleCtrlCheck), true);
        while(StartUp())
        //Console.WriteLine("CTRL+C,CTRL+BREAK or suppress the application to exit");
        while (!isclosing)
        {
            string command = Console.ReadLine();
            if (command.IndexOf("open", StringComparison.CurrentCultureIgnoreCase) > 0)
            {
                OpenIt();
            }
            else if (command.IndexOf("pause", StringComparison.CurrentCultureIgnoreCase) > 0)
            {
                PauseIt();
            }
        }


    }

    private static bool StartUp()
    {
        try
        {
            using (StreamWriter w = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts")))
            {
                w.WriteLine(facebook);
                w.WriteLine(youtube);
            }
        }
        catch (Exception e)
        {

            return false;
        }
        return false;
    }

    private static void PauseIt()
    {
        throw new NotImplementedException();
    }

    private static void OpenIt()
    {
        st = DateTime.UtcNow;
    }

    private static void CloseIt()
    {
        int _try = 0;
        while (StartUp() || _try<100)
        {
            _try++;
        }
    }

    private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
    {
        // Put your own handler here
        switch (ctrlType)
        {
            case CtrlTypes.CTRL_C_EVENT:
                isclosing = true;
                CloseIt();
                Console.WriteLine("CTRL+C received!");
                break;

            case CtrlTypes.CTRL_BREAK_EVENT:
                isclosing = true;
                CloseIt();
                Console.WriteLine("CTRL+BREAK received!");
                break;

            case CtrlTypes.CTRL_CLOSE_EVENT:
                isclosing = true;
                CloseIt();
                Console.WriteLine("Program being closed!");
                break;

            case CtrlTypes.CTRL_LOGOFF_EVENT:
            case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                isclosing = true;
                CloseIt();
                Console.WriteLine("User is logging off!");
                break;

        }
        return true;
    }



    #region unmanaged
    // Declare the SetConsoleCtrlHandler function
    // as external and receiving a delegate.

    [DllImport("Kernel32")]
    public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

    // A delegate type to be used as the handler routine
    // for SetConsoleCtrlHandler.
    public delegate bool HandlerRoutine(CtrlTypes CtrlType);

    // An enumerated type for the control messages
    // sent to the handler routine.
    public enum CtrlTypes
    {
        CTRL_C_EVENT = 0,
        CTRL_BREAK_EVENT,
        CTRL_CLOSE_EVENT,
        CTRL_LOGOFF_EVENT = 5,
        CTRL_SHUTDOWN_EVENT
    }

    #endregion

}


