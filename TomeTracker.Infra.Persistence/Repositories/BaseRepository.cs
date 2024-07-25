using Microsoft.EntityFrameworkCore;

using TomeTracker.Common;
using TomeTracker.Domain.Repositories;
using TomeTracker.Infra.Persistence.Context;

namespace TomeTracker.Infra.Persistence.Repositories;

<<<<<<< HEAD
public class BaseRepository<T> : IBaseRepository<T>
    where T : AggregateRoot
=======
public class BaseRepository<T> : IBaseRepository<T>  where T: AggregateRoot
>>>>>>> 51b38f981f006e722180850a1ecce34fccd476f8
{
    protected readonly TomeTrackerDbContext Context;

    protected BaseRepository(TomeTrackerDbContext context)
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

    public async Task<T?> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id && x.DeletedAt == null, cancellationToken);
    }


    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await Context.Set<T>().Where(t => t.DeletedAt == null).ToListAsync(cancellationToken);
    }
}
