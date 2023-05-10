using BlogApp.Core.Models;
using System.Linq.Expressions;

namespace BlogApp.Core.Repositories
{
    public interface IGenericRepository<T> where T : class 
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Expression<Func<T,bool>>filter);
        List<T> GetAll(Expression<Func<T,bool>>filter = null);
    }
}
