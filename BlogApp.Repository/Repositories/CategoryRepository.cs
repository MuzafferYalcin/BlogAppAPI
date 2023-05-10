using BlogApp.Core.Models;
using BlogApp.Core.Repositories;

namespace BlogApp.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogDbContext context) : base(context)
        {
        }

    }
}
