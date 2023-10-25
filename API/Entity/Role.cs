using System;
using System.Collections.Generic;

namespace API.Entity;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime AddedOn { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
