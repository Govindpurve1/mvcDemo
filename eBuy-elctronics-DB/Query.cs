//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eBuy_elctronics_DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Query
    {
        public Query()
        {
            this.Solutions = new HashSet<Solution>();
        }
    
        public int QueryID { get; set; }
        public Nullable<int> LogiID { get; set; }
        public Nullable<System.DateTime> QueryDate { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Logindetail Logindetail { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; }
    }
}
