namespace TomeTracker.Common.Entities;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Today;
        IsDeleted = false;
    }

    public Guid Id { get; }

    public DateTime CreatedAt { get; protected init; }

    public DateTime? UpdatedAt { get; protected set; }

    public DateTime? DeletedAt { get; protected set; }

    public bool IsDeleted { get; protected set; }

    public void Delete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.Now;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other) { return false; }

        return ReferenceEquals(this, other) || Equals(Id, other.Id);
    }

    public override int GetHashCode()
    {
        return Id!.GetHashCode();
    }

    public static bool operator ==(
        Entity a,
        Entity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) { return true; }

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) { return false; }

        return a.Equals(b);
    }

    public static bool operator !=(
        Entity a,
        Entity b)
    {
        return !(a == b);
    }
}
