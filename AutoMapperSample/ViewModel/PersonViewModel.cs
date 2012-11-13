using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapperSample.ViewModel
{
    public class PersonViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public string FullName { get; set; }

        public string CompanyName { get; set; }
    }
}