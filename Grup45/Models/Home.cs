using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grup45.Models
{
    public class Home
    {
        public int customer { get; set; }
        public int Classic_plus { get; set; }
        public int Elite { get; set; }
        public int Elite_plus { get; set; }
        public List<Customer> CustomerList { get; set; }
    }
}