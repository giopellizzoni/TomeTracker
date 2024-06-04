using TomeTracker.Domain.Aggregates;
using TomeTracker.Domain.Aggregates.Circulations;

namespace TomeTracker.Domain.Repositories;

public interface IBookCirculationRepository: IBaseRepository<BookCirculation>
{
    Task<BookCirculation?> GetCirculation(
        DateTime circulationDate,
        CancellationToken cancellationToken);
}
