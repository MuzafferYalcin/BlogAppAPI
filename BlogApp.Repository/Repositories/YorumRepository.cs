using BlogApp.Core.Models;
using BlogApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Repository.Repositories
{
    public class YorumRepository : GenericRepository<Yorum>, IYorumRepository
    {
        public YorumRepository(BlogDbContext context) : base(context)
        {
        }

        public List<Yorum> GetAllByBlogId(int blogId)
        {
            List<Yorum> yorums = _context.Yorumlar.Where(y => y.BlogId == blogId).ToList();
            return yorums;
        }
        public List<Yorum> GetAllByYazarId(int yazarId)
        {
            List<Yorum> yorums = _context.Yorumlar.Where(y=> y.YazarId == yazarId).ToList();
            return yorums;
        }
    }
}
