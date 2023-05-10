namespace BlogApp.Core.Models
{
    public class Yazar
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Hobiler { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Blog>Bloglar { get; set; }
        public ICollection<Yorum> Yorumlar { get; set; }
    }
}
