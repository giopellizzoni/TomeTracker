using AutoMapper;

using Moq;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Book.Commands;
using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.UnitTest.Application.Commands;

public sealed class CreateBookRequestHandlerTests
{
    [Fact]
    public async Task CreateBook_ValidData_ReturnsBook()
    {
        var book = new Book("Book Title", "Book Author", "ISBN Number", 1950);

        var bookRepository = new Mock<IBookRepository>();
        bookRepository.Setup( b =>  b.Get(It.IsAny<Guid>(), new CancellationToken())).ReturnsAsync(book);

        var unityOfWork = new Mock<IUnityOfWork>();
        unityOfWork.SetupGet(u => u.Books).Returns(bookRepository.Object);

        var mapper = new Mock<IMapper>();
        mapper.Setup(m => m.Map<BookResponse>(It.IsAny<Book>())).Returns(new BookResponse());

        var createBookRequest = new CreateBookRequest(book.Title, book.Author, book.Isbn, book.PublishingYear);
        var createBooRequestHandler = new CreateBookRequestHandler(unityOfWork.Object, mapper.Object);

        var bookResponse = await createBooRequestHandler.Handle(createBookRequest, new CancellationToken());
        Assert.NotNull(bookResponse);

        bookRepository.Verify(br => br.Create(It.IsAny<Book>()), Times.Once);
    }

}
