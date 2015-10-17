//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace BlockSiteWithScheduler
//{
//    public class Program
//    {
//        private static void Main(string[] args)
//        {
//            var instances = Utilities.GetNetworkInterfaces();
//            Console.WriteLine("All available network interfaces:\n");

//            for (var i = 0; i < instances.Count; i++)
//            {
//                Console.WriteLine(i + ": " + instances[i]);
//            }

//            var choice = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Selected network interface:\n" + instances[choice] + "\n\n");

//            while (true)
//            {
//                var stats = Utilities.GetNetworkStatistics(instances[choice]);
//                Console.WriteLine("Download speed: " + stats.DownloadSpeed + " KBytes/s");
//                Console.WriteLine("Upload speed: " + stats.UploadSpeed + " KBytes/s");
//                Console.WriteLine("--------------------------------------------------------------\n\n");
//                Thread.Sleep(1000);
//            }
//        }
//    }
//    public static class StatisticsFactory
//    {
//        private static Queue<float> _latestDownTransfers = new Queue<float>();
//        private static Queue<float> _latestUpTransfers = new Queue<float>();
//        private static Statistics stats;

//        public const int MULTIPLIER = 25;

//        // <summary>
//        // Creates a new statistic and uses the latest transferrates from the previous stats
//        // </summary>
//        public static Statistics CreateStatistics(string interfaceName)
//        {
//            stats = new Statistics(interfaceName)
//            {
//                LatestDownTransfers = _latestDownTransfers,
//                LatestUpTransfers = _latestUpTransfers
//            };

//            return stats;
//        }

//        // <summary>
//        // Adds a value to the current running statistics summary's upload list
//        // </summary>
//        public static void AddSentData(float d)
//        {
//            stats.DataSent = d;
//            if (_latestUpTransfers.Count == 3)
//            {
//                _latestUpTransfers.Dequeue();
//            }
//            _latestUpTransfers.Enqueue(d);

//            stats.LatestUpTransfers = _latestUpTransfers;
//        }

//        // <summary>
//        // Adds a value to the current running statistics summary's download list
//        // </summary>
//        public static void AddReceivedData(float d)
//        {
//            stats.DataReceived = d;

//            if (_latestDownTransfers.Count == 3)
//            {
//                _latestDownTransfers.Dequeue();
//            }

//            _latestDownTransfers.Enqueue(d);

//            stats.LatestDownTransfers = _latestDownTransfers;
//        }
//    }
//    public interface IStatistics
//    {
//        string NetworkInterface { get; }
//        float DataSent { get; }
//        float DataReceived { get; }
//        float UploadSpeed { get; }
//        float DownloadSpeed { get; }
//        Queue<float> LatestDownTransfers { get; }
//        Queue<float> LatestUpTransfers { get; }
//    }

//    public class Statistics : IStatistics
//    {
//        public Statistics(string name)
//        {
//            NetworkInterface = name;
//            LatestDownTransfers = new Queue<float>(3);
//            LatestUpTransfers = new Queue<float>(3);
//        }

//        // <summary>
//        // Holds the name of the selected network interface
//        // </summary>
//        public string NetworkInterface { get; set; }

//        // <summary>
//        // Contains the data sent in the most recent time interval
//        // </summary>
//        public float DataSent { get; set; }

//        // <summary>
//        // Contains the data received in the most recent time interval
//        // </summary>
//        public float DataReceived { get; set; }

//        // <summary>
//        // Returns the upload speed in KiloBytes / Second
//        // </summary>
//        public float UploadSpeed
//        {
//            get { return LatestUpTransfers.Sum() / LatestUpTransfers.Count / 1028 / StatisticsFactory.MULTIPLIER; }
//        }

//        // <summary>
//        // Returns the download speed in KiloBytes / Second
//        // </summary>
//        public float DownloadSpeed
//        {
//            get { return LatestDownTransfers.Sum() / LatestDownTransfers.Count / 1028 / StatisticsFactory.MULTIPLIER; }
//        }

//        // <summary>
//        // Contains the data received in the three most recent time intervals
//        // </summary>
//        public Queue<float> LatestDownTransfers { get; set; }

//        // <summary>
//        // Contains the data sent in the three most recent time intervals
//        // </summary>
//        public Queue<float> LatestUpTransfers { get; set; }
//    }
//    public static class Utilities
//    {
//        static Utilities()
//        {
//            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
//        }

//        // <summary>
//        // Returns statistics about the given network interface
//        // </summary>
//        public static IStatistics GetNetworkStatistics(string interfaceName)
//        {
//            var stats = StatisticsFactory.CreateStatistics(interfaceName);

//            var dataSentCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", interfaceName);
//            var dataReceivedCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", interfaceName);

//            float sendSum = 0;
//            float receiveSum = 0;

//            for (var index = 0; index < StatisticsFactory.MULTIPLIER; index++)
//            {
//                sendSum += dataSentCounter.NextValue();
//                receiveSum += dataReceivedCounter.NextValue();
//            }

//            if (sendSum > 0 || receiveSum > 0)
//            {
//                StatisticsFactory.AddReceivedData(receiveSum);
//                StatisticsFactory.AddSentData(sendSum);
//            }

//            return stats;
//        }

//        // <summary>
//        // Returns a list of all available network interfaces
//        // </summary>
//        public static IList<string> GetNetworkInterfaces()
//        {
//            return new PerformanceCounterCategory("Network Interface").GetInstanceNames().ToList();
//        }
//    }

//}
