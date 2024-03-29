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
    
    public partial class User
    {
        public User()
        {
            this.Agencies = new HashSet<Agency>();
            this.Coupons = new HashSet<Coupon>();
            this.Logs = new HashSet<Log>();
            this.Roles = new HashSet<Role>();
            this.Tokens = new HashSet<Token>();
            this.Trips = new HashSet<Trip>();
        }
    
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public int Spent { get; set; }
        public System.DateTime RegisteredOn { get; set; }
        public Nullable<bool> AccountStatus { get; set; }
    
        public virtual ICollection<Agency> Agencies { get; set; }
        public virtual ICollection<Coupon> Coupons { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
