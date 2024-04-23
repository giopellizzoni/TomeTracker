namespace TomeTracker.Domain.Interfaces;

public interface IUnityOfWork
{
    IBookRepository Books { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task<int> SaveChangesAsync();
}
