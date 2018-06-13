using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBuy_elctronics.Models
{
    public class Items
    {
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public string ItemImageURL { get; set; }
        public int ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
    }
}