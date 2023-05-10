using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int YazarId { get; set; }
        public Yazar Yazar { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Yorum> Yorumlar { get; set; }



    }
}
