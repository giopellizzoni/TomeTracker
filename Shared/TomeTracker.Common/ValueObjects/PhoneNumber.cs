namespace TomeTracker.Common.ValueObjects;

public record PhoneNumber
{
    public string Value { get; }

    private  PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Phone number cannot be empty", nameof(value));
        }

        Value = value;
    }

    public static PhoneNumber Create(string value)
    {
        return new PhoneNumber(value);
    }
}
