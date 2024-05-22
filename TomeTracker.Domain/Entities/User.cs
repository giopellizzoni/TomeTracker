using TomeTracker.Domain.Common;

namespace TomeTracker.Domain.Entities;

public sealed class User: BaseEntity
{
    public User(
        string email,
        string name,
        string role)
    {
        Email = email;
        Name = name;
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
