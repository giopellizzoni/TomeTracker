namespace TomeTracker.Domain.Repositories;

public interface IUnitOfWork
{
    IBookRepository Books { get; }

    IUserRepository Users { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
}
