using Bogus;

using TomeTracker.Domain.Entities;

namespace TomeTracker.UnitTest.Domain;

public sealed class UserTests : IDisposable
{
    private Faker _faker;

    protected Faker Faker => _faker ??= new Faker();

    private User MakeUser()
    {
        var name = Faker.Name.FullName();

        return new User(
            Faker.Internet.Email("FirstName", "LastName"),
            name,
            Faker.Internet.Password(),
            "Admin")
        {
            Id = Guid.NewGuid()
        };
    }

    [Fact]
    public void UserUpdate_UpdateInfo_UserUpdatedValues()
    {
        var user = MakeUser();
        var newName = "NewUserName";
        user.Update(newName);
        Assert.Equal(newName, user.Name);
        Assert.NotNull(user.UpdatedAt);
    }

    [Fact]
    public void UserUpdate_UpdatePassword_UserNewPasswordUpdated()
    {
        var user = MakeUser();
        var newPassword = "NewPassWord";
        user.UpdatePassword(user.Password, newPassword);
        Assert.Equal(newPassword, user.Password);
    }

    public void Dispose()
    {

    }
}
