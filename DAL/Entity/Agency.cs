using System;
using System.Collections.Generic;

namespace DAL.Entity;

public partial class Agency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsInternational { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public virtual User User { get; set; } = null!;
}
