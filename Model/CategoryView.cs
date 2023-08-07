using Microsoft.AspNetCore.Mvc.Rendering;

namespace FYP2.Model
{
    public class CategoryView
    {

        public List<Category>? Category { get; set; }
        public SelectList? Cname { get; set; }
        public int? CatOrder { get; set; }
        
    }
}
