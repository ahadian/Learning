using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FreeSound
{
    public static class ExtensionMethods
    {
        public static void AppendUrlEncoded(this StringBuilder sb, string name, string value, bool moreValues = true)
        {
            sb.Append(HttpUtility.UrlEncode(name));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode(value));
            if (moreValues) sb.Append("&");
        }
        public static Dictionary<string, string> ToDictionary(this object myObj)
        {
            return myObj.GetType()
                .GetProperties()
                .Select(pi => new { Name = pi.Name, Value = pi.GetValue(myObj, null).ToString() })
                .Union(
                    myObj.GetType()
                    .GetFields()
                    .Select(fi => new { Name = fi.Name, Value = fi.GetValue(myObj).ToString() })
                 )
                .ToDictionary(ks => ks.Name, vs => vs.Value);
        }
    }
}
