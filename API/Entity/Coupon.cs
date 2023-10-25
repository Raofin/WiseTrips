using System;
using System.Collections.Generic;

namespace API.Entity;

public partial class Coupon
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int Discount { get; set; }

    public int AddedBy { get; set; }

    public int? SponsoredBy { get; set; }

    public DateTime ExpireOn { get; set; }

    public virtual User AddedByNavigation { get; set; } = null!;

    public virtual Agency? SponsoredByNavigation { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
