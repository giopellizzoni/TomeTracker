namespace TomeTracker.Common.ValueObjects;

public record Email
{
    public string Value { get; private set; }

    private Email(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
        Value = value;
    }

    public static Email From(string value)
    {
        return new Email(value);
    }
}
