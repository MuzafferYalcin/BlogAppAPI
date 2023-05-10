using BlogApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Repositories
{
    public interface IYorumRepository : IGenericRepository<Yorum>
    {
        public List<Yorum> GetAllByBlogId(int blogId);
        public List<Yorum> GetAllByYazarId(int yazarId);
    }

    
}
