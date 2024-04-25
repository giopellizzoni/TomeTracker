using TomeTracker.Domain.Entities;

namespace TomeTracker.Domain.Repositories;

public interface IBookCirculationRepository: IBaseRepository<BookCirculation>
{
    Task<BookCirculation?> GetCirculation(
        DateTime circulationDate,
        CancellationToken cancellationToken);
}
