using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FYP2.Model;

public partial class Orders
{
    public int OrderId { get; set; }

    public string? UserId { get; set; }

    public string? ItemId { get; set; }

    public int Quantity { get; set; }

    public string Note { get; set; } = null!;

    public virtual MenuItem? Item { get; set; }

    public virtual IdentityUser? User { get; set; }
}
