using Ardalis.GuardClauses;

using TomeTracker.Common;

namespace TomeTracker.Domain.Aggregates.Circulations;

public class BookId : ValueObject<BookId>
{
    private long Value { get; }

    private BookId(long id)
    {
        Value = id;
    }

    public static BookId Create(long id)
    {
        Guard.Against.NegativeOrZero(id);

        return new BookId(id);
    }

    public static implicit operator long(BookId self) => self.Value;
}
