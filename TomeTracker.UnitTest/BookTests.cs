using TomeTracker.Domain.Entities;

namespace TomeTracker.UnitTest;

public sealed class BookTests: IDisposable
{
    private Book? _sut = new ("The lord of the rings", "JRR Tolkien", "9780544003415", 1954);

    [Fact]
    public void Create_Book_CreateAtDateIsNotNull()
    {
        Assert.NotNull(_sut!.CreatedAt);
    }

    [Fact]
    public void Delete_Book_DeletedAtIsNotNullAndIsActiveIsFalse()
    {
        _sut!.Delete();

        Assert.NotNull(_sut.DeletedAt);
        Assert.True(_sut.IsActive);
    }

    public void Dispose()
    {
        _sut = null;
    }
}
