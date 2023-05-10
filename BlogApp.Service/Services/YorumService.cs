using BlogApp.Core.Models;
using BlogApp.Core.Repositories;
using BlogApp.Core.Services;
using System.Security.AccessControl;

namespace BlogApp.Service.Services
{
    public class YorumService : Service<Yorum>, IYorumService
    {
        readonly IYorumRepository _yorumRepository;
        public YorumService(IGenericRepository<Yorum> repository, IYorumRepository yorumRepository) : base(repository)
        {
            _yorumRepository = yorumRepository;
        }

        public List<Yorum> GetAllByBLogId(int blogId)
        {
            return _yorumRepository.GetAllByBlogId(blogId);
        }

        public List<Yorum> GetAllByYazarId(int yazarId)
        {
            return _yorumRepository.GetAllByYazarId(yazarId);
        }
        
    }
}
