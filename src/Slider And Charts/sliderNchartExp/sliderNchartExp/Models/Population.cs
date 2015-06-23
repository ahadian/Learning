using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Selise.Cms.Service.Models
{
    public class Population
    {
        public string Category { get; set; }
        public string CategoryLabel { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int Value { get; set; }

    }
}