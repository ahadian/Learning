using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ValueParser
    {
        public static int ParseInt(string value)
        {
            int res = 0;
            int.TryParse(value, out res);
            return res;
        }

        public static double ParseDouble(string value)
        {
            double res = 0;
            double.TryParse(value, out res);
            return res;
        }

        public static int[] ParseIntArray(string value)
        {
            var val = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(value).ToArray();
            return val;
        }

        public static string[] ParseStringArray(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(value).ToArray();
        }

        public static DateTime ParseDate(string value)
        {
            if ("utc".Equals(value, StringComparison.InvariantCultureIgnoreCase))
            {
                return DateTime.UtcNow;
            }
            return DateTime.Parse(value).ToUniversalTime();
        }
    }
}
