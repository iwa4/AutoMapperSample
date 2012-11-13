using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapperSample.Models
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public Company Company { get; set; }
    }
}