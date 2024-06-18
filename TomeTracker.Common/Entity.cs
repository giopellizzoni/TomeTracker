using System.Diagnostics;

namespace TomeTracker.Common;

public abstract class Entity<TId>
{

    public TId Id { get; }

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
        if (obj is not Entity<TId> other) { return false; }

        if (ReferenceEquals(this, other)) { return true; }

        return Equals(Id, other.Id);
    }

    public static bool operator ==(Entity<TId> a, Entity<TId> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) { return true; }
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) { return false; }

        return a.Equals(b);
    }

    public static bool operator !=(Entity<TId> a, Entity<TId> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return Id!.GetHashCode();
    }
}
