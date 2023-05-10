using BlogApp.Core.Models;
using BlogApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Repository.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogDbContext context) : base(context)
        {
        }

        public List<Blog> GetBlogWithYazarCategory()
        {
            return _context.Bloglar.Include(b => b.Category).Include(b=> b.Yazar).ToList();
        }
       
    }
}
