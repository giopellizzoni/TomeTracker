using System.Reflection;

using Microsoft.EntityFrameworkCore;

using TomeTracker.Domain.Aggregates;
using TomeTracker.Domain.Aggregates.Books;
using TomeTracker.Domain.Aggregates.Circulations;
using TomeTracker.Domain.Aggregates.Users;

namespace TomeTracker.Infra.Persistence.Context;

public class TomeTrackerDbContext : DbContext
{
    public TomeTrackerDbContext(DbContextOptions<TomeTrackerDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BookCirculation> Circulations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
