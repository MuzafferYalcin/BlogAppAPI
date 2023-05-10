using BlogApp.Core.Models;
using BlogApp.Core.Repositories;
using BlogApp.Core.Services;

namespace BlogApp.Service.Services
{
    public class ContactService : Service<Contact>,IContactService
    {
        public ContactService(IGenericRepository<Contact> repository) : base(repository)
        {
        }
    }
}
