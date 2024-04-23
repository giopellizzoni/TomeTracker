using TomeTracker.Domain.Entities;

namespace TomeTracker.Domain.Repositories;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<Book?> GetByISBN(
        string isbn,
        CancellationToken cancellationToken);

    Task<Book?> GetByName(
        string name,
        CancellationToken cancellationToken);
}
