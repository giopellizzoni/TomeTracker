namespace TomeTracker.Books.Domain.Entities;

public sealed record PageCount
{
    public int Value { get; }

    private PageCount(int value)
    {
        Value = value;
    }

    public static PageCount Create(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Page count must be greater than 0", nameof(value));
        }

        return new PageCount(value);
    }
}
