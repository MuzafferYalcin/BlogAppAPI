using BlogApp.Core.Repositories;
using BlogApp.Core.Services;
using System.Linq.Expressions;

namespace BlogApp.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        readonly IGenericRepository<T> _repository;

        public Service(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _repository.Get(filter);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
           return _repository.GetAll(filter);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
