using Microsoft.EntityFrameworkCore;

using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;
using TomeTracker.Infra.Persistence.Context;

namespace TomeTracker.Infra.Persistence.Repositories;

public sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(TomeTrackerDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmail(
        string email,
        CancellationToken cancellationToken)
    {
        return await Context.Users.FirstOrDefaultAsync(
            u => u.Email.Equals(email), cancellationToken);
    }
}
