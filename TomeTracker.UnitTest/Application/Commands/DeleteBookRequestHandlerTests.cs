using Moq;

using TomeTracker.Application.UseCases.Book.Commands;
using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.UnitTest.Application.Commands;

public sealed class DeleteBookRequestHandlerTests
{
    [Fact]
    public async Task DeleteBook_ValidId_ReturnsNoContent()
    {
        var book = new Book("Book Title", "Book Author", "ISBN Number", 1950) { Id = Guid.NewGuid() };
        var bookRepository = new Mock<IBookRepository>();
        bookRepository.Setup( b =>  b.Get(It.IsAny<Guid>(), new CancellationToken())).ReturnsAsync(book);

        var unityOfWork = new Mock<IUnityOfWork>();
        unityOfWork.SetupGet(u => u.Books).Returns(bookRepository.Object);

        var deleteBookRequest = new DeleteBookRequest(book.Id);
        var deleteBookRequestHandler = new DeleteBookRequestHandler(unityOfWork.Object);

        await deleteBookRequestHandler.Handle(deleteBookRequest, new CancellationToken());

        Assert.NotNull(book.DeletedAt);
    }
}