using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBuyelctronics.Models
{
    public class CraditDetails
    {
        public int OrderItemId { get; set; }
        public int OrderQuantity { get; set; }
        public int LoginId { get; set; }

        public string Type { get; set; }
        public string CcNumber { get; set; }
        public string CName { get; set; }
        public int Cvv { get; set; }
        public string Exp { get; set; }
        public string Street { get; set; }
        public string CityID { get; set; }
        public string StateID { get; set; }
        public string CountryID { get; set; }
        public int Zipcode { get; set; }
    }
}