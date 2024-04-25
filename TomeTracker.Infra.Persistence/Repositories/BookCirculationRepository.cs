using Microsoft.EntityFrameworkCore;

using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;
using TomeTracker.Infra.Persistence.Context;

namespace TomeTracker.Infra.Persistence.Repositories;

public sealed class BookCirculationRepository : BaseRepository<BookCirculation>, IBookCirculationRepository
{
    private BookCirculationRepository(TomeTrackerDbContext context) : base(context)
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
