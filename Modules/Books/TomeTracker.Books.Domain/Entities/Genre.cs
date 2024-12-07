namespace TomeTracker.Books.Domain.Entities;

public sealed record Genre
{
    public string Value { get; }

    private Genre(string value)
    {
        Value = value;
    }

    public static Genre Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Genre cannot be empty", nameof(value));
        }

        return new Genre(value);
    }
}
