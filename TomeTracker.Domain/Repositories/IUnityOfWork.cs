namespace TomeTracker.Domain.Repositories;

public interface IUnityOfWork
{
    IBookRepository Books { get; }

    IUserRepository Users { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
}
