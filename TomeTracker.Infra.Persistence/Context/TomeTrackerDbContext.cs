using System.Reflection;

using Microsoft.EntityFrameworkCore;

using TomeTracker.Domain.Entities;

namespace TomeTracker.Infra.Persistence.Context;

public class TomeTrackerDbContext : DbContext
{
    public TomeTrackerDbContext(DbContextOptions<TomeTrackerDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
