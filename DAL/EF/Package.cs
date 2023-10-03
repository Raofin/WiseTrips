using System;
using System.Collections.Generic;

namespace DAL.EF;

public partial class Package
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AgencyId { get; set; }

    public string Country { get; set; } = null!;

    public string Details { get; set; } = null!;

    public int Duration { get; set; }

    public int Price { get; set; }

    public virtual Agency Agency { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
