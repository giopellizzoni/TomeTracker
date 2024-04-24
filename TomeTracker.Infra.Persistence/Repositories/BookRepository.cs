using Microsoft.EntityFrameworkCore;

using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;
using TomeTracker.Infra.Persistence.Context;

namespace TomeTracker.Infra.Persistence.Repositories;

public class BookRepository: BaseRepository<Book>, IBookRepository
{
    public BookRepository(TomeTrackerDbContext context) : base(context)
    {
    }

    public async Task<Book?> GetByISBN(
        string isbn,
        CancellationToken cancellationToken)
    {
        return await Context.Books.SingleOrDefaultAsync(b => b.Isbn.Equals(isbn), cancellationToken);
    }

    public async Task<Book?> GetByName(
        string name,
        CancellationToken cancellationToken)
    {
        return await Context.Books.SingleOrDefaultAsync(b => b.Title.Equals(name), cancellationToken);
    }
}
