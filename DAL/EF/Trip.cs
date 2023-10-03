using System;
using System.Collections.Generic;

namespace DAL.EF;

public partial class Trip
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PackageId { get; set; }

    public int HotelId { get; set; }

    public int Persons { get; set; }

    public DateTime Date { get; set; }

    public int? UsedCoupon { get; set; }

    public int Paid { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;

    public virtual Coupon? UsedCouponNavigation { get; set; }

    public virtual User User { get; set; } = null!;
}
