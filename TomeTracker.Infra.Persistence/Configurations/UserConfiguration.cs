using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TomeTracker.Domain.Aggregates;
using TomeTracker.Domain.Aggregates.Users;

namespace TomeTracker.Infra.Persistence.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Email)
            .IsRequired();

        builder
            .Property(u => u.Name)
            .IsRequired();
    }
}
