//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Package
    {
        public Package()
        {
            this.Histories = new HashSet<History>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int AgencyId { get; set; }
        public string Country { get; set; }
        public string Details { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
    
        public virtual Agency Agency { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
