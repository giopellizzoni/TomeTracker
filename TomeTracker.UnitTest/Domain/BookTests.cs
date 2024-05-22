using TomeTracker.Domain.Entities;

namespace TomeTracker.UnitTest.Domain;

public sealed class BookTests: IDisposable
{
    private Book? _sut = new ("The lord of the rings", "JRR Tolkien", "9780544003415", 1954);

    [Fact]
    public void Delete_Book_DeletedAtIsNotNullAndIsActiveIsFalse()
    {
        _sut!.Delete();

        Assert.NotNull(_sut.DeletedAt);
    }

    public void Dispose()
    {
        _sut = null;
    }
}
