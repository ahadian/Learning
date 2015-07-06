using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkRnd
{
    public class Activity
    {
        public Activity()
        {
            PerformanceIndicators = new List<PerformanceIndicator>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ActivityId { get; set; }
        public string Description { get; set; }
        public Guid ObjectiveId { get; set; }
        public virtual Objective Objective { get; set; }
        public virtual ICollection<PerformanceIndicator> PerformanceIndicators { get; set; }
       
    }
}
