using System;
using System.Collections.Generic;

namespace FYP2.Model;

public partial class Restaurants
{
    public int RestaurantId { get; set; }

    public string Rname { get; set; } = null!;

    public string Raddress { get; set; } = null!;
}
