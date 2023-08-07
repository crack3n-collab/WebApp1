using System;
using System.Collections.Generic;

namespace FYP2.Models;

public partial class AdminUsers
{
    public string UserId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public byte[] UserPass { get; set; } = null!;
}
