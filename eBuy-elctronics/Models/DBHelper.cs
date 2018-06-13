using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eBuy_elctronics_DB;

namespace eBuy_elctronics.Models
{
    public class DBHelper
    {
        Entities DB = new Entities();
        public void Brands()
        {
            var Data = DB.Brands.ToList();

        }
    }
}