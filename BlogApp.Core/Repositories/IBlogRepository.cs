﻿using BlogApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Repositories
{
    public interface IBlogRepository : IGenericRepository<Blog> 
    {
        public List<Blog> GetBlogWithYazarCategory();
    }
}
