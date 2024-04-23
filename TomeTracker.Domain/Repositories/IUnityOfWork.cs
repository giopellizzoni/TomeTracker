namespace TomeTracker.Domain.Repositories;

public interface IUnityOfWork
{
    IBookRepository Books { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task<int> SaveChangesAsync();
}
