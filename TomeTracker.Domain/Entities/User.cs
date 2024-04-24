using TomeTracker.Domain.Common;

namespace TomeTracker.Domain.Entities;

public class User: BaseEntity
{
    public User(
        string email,
        string name)
    {
        Email = email;
        Name = name;
    }

    public string Name { get; set; }
    public string Email { get; set; }

    public void Update(
        string name,
        string email)
    {
        Name = name;
        Email = email;
        UpdatedAt = DateTime.Now;
    }
}
