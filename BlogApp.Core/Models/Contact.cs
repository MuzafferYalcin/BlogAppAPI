namespace BlogApp.Core.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsActive { get; set; }
    }
}
