using TomeTracker.Common;

namespace TomeTracker.Domain.Repositories;

public interface IBaseRepository<T> where T : AggregateRoot
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> GetById(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
