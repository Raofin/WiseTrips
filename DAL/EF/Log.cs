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
    
    public partial class Log
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Action { get; set; }
        public string OldUsername { get; set; }
        public string OldEmail { get; set; }
        public string OldPassword { get; set; }
        public string NewUsername { get; set; }
        public string NewEmail { get; set; }
        public string NewPassword { get; set; }
        public System.DateTime DateTime { get; set; }
    
        public virtual User User { get; set; }
    }
}
