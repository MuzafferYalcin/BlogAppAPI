using BlogApp.Core.Models;
using BlogApp.Core.Repositories;
using BlogApp.Core.Services;

namespace BlogApp.Service.Services
{
    public class YazarService : Service<Yazar>, IYazarService
    {
        public YazarService(IGenericRepository<Yazar> repository) : base(repository)
        {
        }
    }
}
