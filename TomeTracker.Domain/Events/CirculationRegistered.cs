using TomeTracker.Common;

namespace TomeTracker.Domain.Events;

public class CirculationRegistered: IEvent
{
    public Guid Id { get; set; }
    public long BookId { get; set; }
    public DateTime CirculationDate { get; set; }

    public DateTime EndDate { get; set; }

    public CirculationRegistered(Guid id,
        long bookId,
        DateTime circulationDate, DateTime endDate)
    {
        Id = id;
        BookId = bookId;
        CirculationDate = circulationDate;
        EndDate = endDate;
    }
}
