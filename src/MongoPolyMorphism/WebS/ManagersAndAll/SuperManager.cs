using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.ManagersAndAll
{
    public static class SuperManager
    {
        public static class Rand
        {
             public static string Id()
            {
                return Guid.NewGuid().ToString();
            }

            public static string String()
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random();
                return new string(Enumerable.Repeat(chars, random.Next(5))
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }

            public static int Int()
            {
                return new Random().Next();
            }

            public static DateTime Date() 
            {
                DateTime start = new DateTime(1995, 1, 1);
                Random gen = new Random();
                int range = (DateTime.Today - start).Days;           
                return start.AddDays(gen.Next(range));
            }

            public static string[] StringArray()
            {
                return new string[] { String(), String() };
            }
        }
        
    }
}