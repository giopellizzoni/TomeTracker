using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TomeTracker.Domain.Aggregates;
using TomeTracker.Domain.Aggregates.Circulations;

namespace TomeTracker.Infra.Persistence.Configurations;

public class BookCirculationConfiguration: IEntityTypeConfiguration<BookCirculation>
{
    public void Configure(EntityTypeBuilder<BookCirculation> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.UserId)
            .IsRequired();

        builder
            .Property(b => b.BookId)
            .IsRequired();

        builder
            .Property(b => b.CirculationDate.StartDate)
            .IsRequired();

        builder
            .Property(b => b.CirculationDate.EndDate);
    }
}
