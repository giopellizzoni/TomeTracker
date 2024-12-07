using TomeTracker.Common.Entities;

namespace TomeTracker.Common.Persistence.Repository;

public interface IWritableRepository<T>: IReadableRepository<T> where T : Entity
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
