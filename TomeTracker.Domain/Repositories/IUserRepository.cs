using TomeTracker.Domain.Aggregates.Users;

namespace TomeTracker.Domain.Repositories;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> GetByEmail(
        string email,
        CancellationToken cancellationToken);
}
