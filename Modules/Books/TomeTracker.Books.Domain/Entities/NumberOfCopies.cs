namespace TomeTracker.Books.Domain.Entities;

public sealed record NumberOfCopies
{
    public int Value { get; }

    private NumberOfCopies(int value)
    {
        Value = value;
    }

    public static NumberOfCopies Create(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Number of copies must be greater than 0", nameof(value));
        }

        return new NumberOfCopies(value);
    }
}
