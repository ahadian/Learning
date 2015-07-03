using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWithGenerics
{
    public class Pen : BaseEntity
    {
        public string Brand { get; set; }
        public string Weight { get; set; }
        public string Price { get; set; }
    }
}
