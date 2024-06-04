using Microsoft.EntityFrameworkCore;

using TomeTracker.Domain.Aggregates;
using TomeTracker.Domain.Aggregates.Circulations;
using TomeTracker.Domain.Repositories;
using TomeTracker.Infra.Persistence.Context;

namespace TomeTracker.Infra.Persistence.Repositories;

public sealed class BookCirculationRepository : BaseRepository<BookCirculation>, IBookCirculationRepository
{
    public BookCirculationRepository(TomeTrackerDbContext context) : base(context)
    {
    }

    public async Task<BookCirculation?> GetCirculation(
        DateTime circulationDate,
        CancellationToken cancellationToken)
    {
        return await Context.Circulations.FirstOrDefaultAsync(
            bc => bc.CirculationDate.Equals(circulationDate),
            cancellationToken: cancellationToken);
    }
}
