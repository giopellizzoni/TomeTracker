namespace TomeTracker.Domain.Repositories;

public interface IUnitOfWork
{
    IBookRepository Books { get; }

    IUserRepository Users { get; }

    IBookCirculationRepository Circulations { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
}
