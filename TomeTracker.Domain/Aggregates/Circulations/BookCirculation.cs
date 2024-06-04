using TomeTracker.Common;
using TomeTracker.Domain.Aggregates.Circulations.ValueObjects;

namespace TomeTracker.Domain.Aggregates.Circulations;

public sealed class BookCirculation : AggregateRoot
{
    public BookCirculation(UserId userId, BookId bookId)
    {
        UserId = userId;
        BookId = bookId;
        CirculationDate = CirculationDate.StartCirculation(DateTime.Today);
    }

    public UserId UserId { get; private set; }
    public BookId BookId { get; private set; }
    public CirculationDate CirculationDate { get; private set; }

    public void EndCirculationOnDate(DateTime endDate)
    {
        CirculationDate = CirculationDate.FinishCirculation(endDate);
    }
}
