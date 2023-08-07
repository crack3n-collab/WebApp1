using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

using FYP2.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FYP2.Model
{
    [PrimaryKey(nameof(OrderID), nameof(ItemId))]
    public partial class OrderItem
    {
   
        [ForeignKey("Orders")]
        public int OrderID { get; set; }

  
        [ForeignKey("MenuItem")]
        public string ItemId { get; set; }
        //public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Orders Order { get; set; }
    }
}
