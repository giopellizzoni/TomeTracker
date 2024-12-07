namespace TomeTracker.Books.Domain.Entities;

public sealed record PublicationYear
{
    public int Value { get; }

    private PublicationYear(int value)
    {
        Value = value;
    }

    public static PublicationYear Create(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Publication year cannot be negative", nameof(value));
        }

        return new PublicationYear(value);
    }
}