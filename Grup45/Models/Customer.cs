using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grup45.Models
{
    public class Customer
    {
        public int Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Passaport_number { get; set; }
        public string Customer_phone { get; set; }
        public string Country { get; set; }
        public string E_mail { get; set; }
        public string Adress { get; set; }
        public float Total_miles { get; set; }
        public string Type_flag { get; set; }
        public string Classic_Plus_award { get; set; }
        public string Elite_award { get; set; }
        public string Elite_Plus_award { get; set; }
    }
}