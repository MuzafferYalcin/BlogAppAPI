using BlogApp.Core.Models;
using BlogApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Repository.Repositories
{
    public class YazarRepository : GenericRepository<Yazar>, IYazarRepository
    {
        public YazarRepository(BlogDbContext context) : base(context)
        {
        }
    }
}
