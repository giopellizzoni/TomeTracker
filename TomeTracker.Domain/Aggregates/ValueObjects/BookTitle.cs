using Ardalis.GuardClauses;

using TomeTracker.Common;

namespace TomeTracker.Domain.Aggregates.ValueObjects;

public class BookTitle: ValueObject<BookTitle>
{
    public string Value { get; private set; }

    private BookTitle(string title)
    {
        Guard.Against.Null(title);
        Guard.Against.StringTooLong(title, 100);

        Value = title;
    }

    public static BookTitle FromTitle(string title)
    {
        return new BookTitle(title);
    }

}
