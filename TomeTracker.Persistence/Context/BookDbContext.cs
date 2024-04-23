using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TomeTracker.Domain.Entities;

namespace TomeTracker.Persistence.Context;

public class BookDbContext: DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
