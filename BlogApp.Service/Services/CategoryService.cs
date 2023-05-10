using BlogApp.Core.Models;
using BlogApp.Core.Repositories;
using BlogApp.Core.Services;

namespace BlogApp.Service.Services
{
    public class CategoryService : Service<Category> , ICategoryService
    {
        public CategoryService(IGenericRepository<Category> repository) : base(repository)
        {
        }
    }
}
