using Microsoft.EntityFrameworkCore.Storage;
using TomeTracker.Domain.Repositories;
using TomeTracker.Infra.Persistence.Context;

namespace TomeTracker.Infra.Persistence.Repositories;

public class UnityOfWork: IUnityOfWork
{
    private readonly TomeTrackerDbContext _context;
    private IDbContextTransaction _transaction;
    public UnityOfWork(TomeTrackerDbContext context, IBookRepository bookRepository)
    {
        _context = context;
        Books = bookRepository;
    }

    public IBookRepository Books { get; }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception)
        {
            await _transaction.RollbackAsync();
            throw;
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
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
