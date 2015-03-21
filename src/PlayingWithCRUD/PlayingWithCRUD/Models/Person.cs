using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayingWithCRUD.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonPhoneNumber { get; set; }
        public int PersonAge { get; set; }

    }
}