using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TomeTracker.Domain.Aggregates;
using TomeTracker.Domain.Aggregates.Books;

namespace TomeTracker.Infra.Persistence.Configurations;

public class BookConfiguration: IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Title)
            .HasMaxLength(60)
            .IsRequired();

        builder
            .Property(b => b.Author)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(b => b.Isbn)
            .IsRequired();

        builder
            .Property(b => b.PublishingYear)
            .IsRequired();
    }
}
