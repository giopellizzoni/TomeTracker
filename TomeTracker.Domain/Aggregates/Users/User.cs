using TomeTracker.Common;
using TomeTracker.Domain.Aggregates.ValueObjects;

namespace TomeTracker.Domain.Aggregates.Users;

public sealed class User: AggregateRoot<Guid>
{
    public User(
        string email,
        string name,
        string password,
        string role)
    {
        Email = email;
        Name = name;
        Password = password;
        Role = role;
        CreatedAt = DateTime.Now;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }

    public void Update(
        string name)
    {
        Name = name;
        UpdatedAt = DateTime.Now;
    }

    public void UpdatePassword(
        string currentPassword,
        string newPassword)
    {
        if (Password.Equals(currentPassword))
        {
            Password = newPassword;
        }
    }
}
