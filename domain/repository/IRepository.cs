using System.Linq.Expressions;

namespace e08.domain.repository;

public interface IRepository<T> where T : class, new()
{
    Task<T> Get(String id);
    Task<T> Find(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}