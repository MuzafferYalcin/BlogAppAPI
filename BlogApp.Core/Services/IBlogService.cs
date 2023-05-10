using BlogApp.Core.Models;

namespace BlogApp.Core.Services
{
    public interface IBlogService : IService<Blog> 
    {
        public List<Blog> GetBlogWithYazarCategory();
    }
}
