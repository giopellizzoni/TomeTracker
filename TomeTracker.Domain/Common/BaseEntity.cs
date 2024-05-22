namespace TomeTracker.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; protected init; }

    public DateTime? UpdatedAt { get; protected set; }

    public DateTime? DeletedAt { get; protected set; }

    public bool IsDeleted { get; protected set; }

    public void Delete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.Now;
    }
}
