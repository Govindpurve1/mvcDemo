using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBuy_elctronics.Models
{
    public class ChangePasword
    {
        public string username { get; set; }
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
    }
}