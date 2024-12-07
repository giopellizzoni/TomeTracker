namespace TomeTracker.Books.Domain.Entities;

public sealed record Isbn
{
    public string Value { get; }

    private Isbn(string value)
    {
        Value = value;
    }

    public static Isbn Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("ISBN cannot be empty", nameof(value));
        }

        return new Isbn(value);
    }
}
