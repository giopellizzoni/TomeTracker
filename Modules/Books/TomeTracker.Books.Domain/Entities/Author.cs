namespace TomeTracker.Books.Domain.Entities;

public sealed record Author
{
    public string Value { get; }
    private Author(string value)
    {
        Value = value;
    }
    public static Author Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Author name cannot be empty", nameof(value));
        }
        return new Author(value);
    }
}
