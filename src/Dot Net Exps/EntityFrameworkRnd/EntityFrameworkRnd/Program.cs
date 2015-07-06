using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkRnd
{
    class Program
    {
        static void Main(string[] args)
        {
            EFRepo db = new EFRepo();
            var objectives = db.Objectives.ToList();
            var activities = db.Activities.ToList();
            var pis = db.PerformanceIndicators.ToList();
        }
    }
}
