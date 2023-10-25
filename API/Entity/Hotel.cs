using System;
using System.Collections.Generic;

namespace API.Entity;

public partial class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Star { get; set; }

    public int Price { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
