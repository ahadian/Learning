using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkRnd
{
    public class Objective
    {
        public Objective()
        {
            Activities = new List<Activity>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ObjectiveId { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
