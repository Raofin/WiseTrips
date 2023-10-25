using System;
using System.Collections.Generic;

namespace DAL.Entity;

public partial class Token
{
    public int Id { get; set; }

    public string AuthToken { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime ExpiredOn { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
