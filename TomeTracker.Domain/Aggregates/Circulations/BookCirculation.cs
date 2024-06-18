using TomeTracker.Common;
using TomeTracker.Domain.Aggregates.ValueObjects;

namespace TomeTracker.Domain.Aggregates.Circulations;

public sealed class BookCirculation : AggregateRoot<Guid>
{
    public BookCirculation(UserId userId, BookId bookId)
    {
        UserId = userId;
        BookId = bookId;
        CirculationDate = CirculationDate.StartCirculation(DateTime.Today);
    }

    public BookCirculation()
    {
    }

    public UserId UserId { get; private set; }
    public BookId BookId { get; private set; }
    public CirculationDate CirculationDate { get; private set; }

    public void RegisterEndCirculationDate(DateTime endDate)
    {
        CirculationDate = CirculationDate.FinishCirculation(endDate);
    }
}
