using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeSound
{
    public class SoundCouldSearchResult
    {
        public int count { get; set; }
        public string next { get; set; }
        public Sound[] results { get; set; }
    }
}
