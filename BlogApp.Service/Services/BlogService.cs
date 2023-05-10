using BlogApp.Core.Models;
using BlogApp.Core.Repositories;
using BlogApp.Core.Services;

namespace BlogApp.Service.Services
{
    public class BlogService : Service<Blog>,IBlogService
    {
        readonly IBlogRepository _blogRepository;
        public BlogService(IGenericRepository<Blog> repository, IBlogRepository blogRepository) : base(repository)
        {
            _blogRepository = blogRepository;
        }

        public List<Blog> GetBlogWithYazarCategory()
        {
            return _blogRepository.GetBlogWithYazarCategory();
        }
    }
}
