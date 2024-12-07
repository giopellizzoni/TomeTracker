namespace TomeTracker.Books.Domain.Entities;

public sealed record Title
{
    public string Value { get; }

    private Title(string value)
    {
        Value = value;
    }

    public static Title Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Book name cannot be empty", nameof(value));
        }

        return new Title(value);
    }
}
