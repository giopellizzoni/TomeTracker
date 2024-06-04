using Ardalis.GuardClauses;

using TomeTracker.Common;

namespace TomeTracker.Domain.Aggregates.Circulations;

public class UserId: ValueObject<UserId>
{
    private long Value { get; }

    private UserId(long id)
    {
        Value = id;
    }

    public static UserId Create(long id)
    {
        Guard.Against.NegativeOrZero(id);

        return new UserId(id);
    }

    public static implicit operator long(UserId self) => self.Value;
}
