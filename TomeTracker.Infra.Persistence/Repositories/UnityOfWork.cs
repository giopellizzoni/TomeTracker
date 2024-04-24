using Microsoft.EntityFrameworkCore.Storage;
using TomeTracker.Domain.Repositories;
using TomeTracker.Infra.Persistence.Context;

namespace TomeTracker.Infra.Persistence.Repositories;

public class UnityOfWork: IUnityOfWork
{
    private readonly TomeTrackerDbContext _context;
    private IDbContextTransaction _transaction;
    public UnityOfWork(TomeTrackerDbContext context, IBookRepository bookRepository, IUserRepository userRepository)
    {
        _context = context;
        Books = bookRepository;
        Users = userRepository;
    }

    public IBookRepository Books { get; }

    public IUserRepository Users { get; }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch (Exception)
        {
            await _transaction.RollbackAsync();
            throw;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if(disposing)
        {
            _context.Dispose();
        }
    }
}
