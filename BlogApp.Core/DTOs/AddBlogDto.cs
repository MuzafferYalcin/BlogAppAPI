using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.DTOs
{
    public class AddBlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int YazarId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public IFormFile Image { get; set; }
    }
}
