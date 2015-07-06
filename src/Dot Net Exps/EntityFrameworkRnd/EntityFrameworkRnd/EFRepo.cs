using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkRnd
{
    public class EFRepo : DbContext
    {
        public EFRepo()
            : base("EF_Exp")
        {
            
        }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<PerformanceIndicator> PerformanceIndicators { get; set; }
    }
}
