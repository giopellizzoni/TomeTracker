using Microsoft.EntityFrameworkCore.Storage;

using TomeTracker.Domain.Repositories;
using TomeTracker.Infra.Persistence.Context;

namespace TomeTracker.Infra.Persistence.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly TomeTrackerDbContext _context;
    private IDbContextTransaction _transaction;

    public UnitOfWork(
        TomeTrackerDbContext context,
        IBookRepository bookRepository,
        IUserRepository userRepository,
        IBookCirculationRepository circulations)
    {
        _context = context;
        Books = bookRepository;
        Users = userRepository;
        Circulations = circulations;
    }

    public IBookRepository Books { get; }
    public IUserRepository Users { get; }
    public IBookCirculationRepository Circulations { get; }

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
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}
