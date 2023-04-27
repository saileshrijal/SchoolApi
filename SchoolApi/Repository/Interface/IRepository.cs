using System.Linq.Expressions;

namespace SchoolApi.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Get(Expression<Func<T, bool>> predicate);
    }
}
