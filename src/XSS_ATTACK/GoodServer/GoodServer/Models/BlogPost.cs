using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoodServer.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string Post { get; set; }
        public string Title { get; set; }
    }
    
}