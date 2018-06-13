using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBuy_elctronics.Models
{
    public class Registration
    {
        public string Loginid { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }


        public string Logintype { get; set; }

        public string Squestionid { get; set; }
        public string Sanswer { get; set; }

        public string Firstlogin { get; set; }
        public string Passmodifieddate { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string IsDeleted { get; set; }
        public string IsActive { get; set; }

        public int Id { get; set; }

        public string Birthdate { get; set; }
        public string Hno { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Locale { get; set; }




    }
}