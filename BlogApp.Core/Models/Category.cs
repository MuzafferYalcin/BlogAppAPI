namespace BlogApp.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Blog> Bloglar { get; set; }
    }
}
