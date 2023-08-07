using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using static NuGet.Packaging.PackagingConstants;

namespace FYP2.Model
{
    public class MenuItem
    {
        public string Id { get; set; } = null!;

        public string? CatId { get; set; }

        public string Iname { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string Idescription { get; set; } = null!;

        public virtual Category? Cat { get; set; }
       
        //public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();

    }
}
