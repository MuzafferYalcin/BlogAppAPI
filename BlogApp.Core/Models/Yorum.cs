using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Core.Models
{
    public class Yorum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int YazarId { get; set; }
        public Yazar Yazar { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}
