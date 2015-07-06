using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkRnd
{
    public class PerformanceIndicator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PerformanceIndicatorId { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public string Status { get; set; }
        public Boolean? IsCompleted { get; set; }
        public Boolean? IsApproved { get; set; }
        public Guid? ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
