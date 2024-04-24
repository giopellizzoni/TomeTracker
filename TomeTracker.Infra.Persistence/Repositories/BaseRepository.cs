using Microsoft.EntityFrameworkCore;

using TomeTracker.Domain.Common;
using TomeTracker.Domain.Repositories;
using TomeTracker.Infra.Persistence.Context;

namespace TomeTracker.Infra.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T: BaseEntity
{
    protected readonly TomeTrackerDbContext Context;

    public BaseRepository(TomeTrackerDbContext context)
    {
        Context = context;
    }

    public void Create(T entity)
    {
        Context.Add(entity);
    }

    public void Update(T entity)
    {
        Context.Update(entity);
    }

    public void Delete(T entity)
    {
        Context.Remove(entity);
    }

    public async Task<T?> Get(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await Context.Set<T>().ToListAsync(cancellationToken);
    }
}
