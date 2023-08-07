using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

using FYP2.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FYP2.Model;

public partial class Orders
{

    public int Id { get; set; } //order id 

    public string UserId { get; set; }

    //public string? ItemId { get; set; }

    //public int Quantity { get; set; }

    public string Note { get; set; } = null!;

    // Navigation property
    public ICollection<OrderItem> Items { get; set; }
    //public virtual WebApp1User? User { get; set; }
    public WebApp1User User { get; set; }
}
