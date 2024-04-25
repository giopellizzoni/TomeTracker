using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TomeTracker.Domain.Entities;

namespace TomeTracker.Infra.Persistence.Configurations;

public class BookCirculationConfiguration: IEntityTypeConfiguration<BookCirculation>
{
    public void Configure(EntityTypeBuilder<BookCirculation> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.IdUser)
            .IsRequired();

        builder
            .Property(b => b.IdBook)
            .IsRequired();

        builder
            .Property(b => b.CirculationDate)
            .IsRequired();
    }
}
