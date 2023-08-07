namespace FYP2.Model
{
    public class Category
    {
        public String Id { get; set; } = null!;
        //public string CatId { get; set; } = null!;

        public string Cname { get; set; } = null!;

        public int? CatOrder { get; set; }

        //public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
