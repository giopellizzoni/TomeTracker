namespace TomeTracker.Common.ValueObjects;

public record Address
{
    public string Street { get; init; }

    public string City { get; init; }

    public string State { get; init; }

    public string ZipCode { get; init; }

    public string Country { get; init; }

    public Address(
        string street,
        string city,
        string state,
        string zipCode,
        string country)
    {
        ArgumentException.ThrowIfNullOrEmpty(street, nameof(street));
        ArgumentException.ThrowIfNullOrEmpty(city, nameof(city));
        ArgumentException.ThrowIfNullOrEmpty(state, nameof(state));
        ArgumentException.ThrowIfNullOrEmpty(zipCode, nameof(zipCode));
        ArgumentException.ThrowIfNullOrEmpty(country, nameof(country));

        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Country = country;
    }

    public static Address Of(
        string street,
        string city,
        string state,
        string zipCode,
        string country)
    {
        return new Address(street, city, state, zipCode, country);
    }
}
