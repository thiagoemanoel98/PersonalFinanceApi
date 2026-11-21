using System.Linq.Expressions;

namespace PersonalFinance.Api.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);

    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
}