using System;
using System.Collections.Generic;

namespace API.Entity;

public partial class Log
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Action { get; set; } = null!;

    public string? OldUsername { get; set; }

    public string? OldEmail { get; set; }

    public string? OldPassword { get; set; }

    public string? NewUsername { get; set; }

    public string? NewEmail { get; set; }

    public string? NewPassword { get; set; }

    public DateTime DateTime { get; set; }

    public virtual User? User { get; set; }
}
