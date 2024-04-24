using AutoMapper;

using Moq;

using TomeTracker.Application.UseCases.Book.GetBookById;
using TomeTracker.Application.UseCases.Book.Models;
using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.UnitTest;

public class GetBookByIdQueryTests
{
    [Fact]
    public async Task GetBookById_CallingId_ReturnsBook()
    {
        var book = new Book("Book Title", "Book Author", "ISBN Number", 1950);

        var bookRepository = new Mock<IBookRepository>();
        bookRepository.Setup(b => b.Get(It.IsAny<Guid>(), new CancellationToken()).Result).Returns(book);

        var unityOfWork = new Mock<IUnityOfWork>();
        unityOfWork.SetupGet(u => u.Books).Returns(bookRepository.Object);

        var mapper = new Mock<IMapper>();

        mapper.Setup(m => m.Map<BookResponse>(It.IsAny<Book>())).Returns(new BookResponse());

        var getBookByIdQuery = new GetBookByIdQuery(Guid.NewGuid());
        var getBookByIdQueryHandler = new GetBookByIdQueryHandler(unityOfWork.Object, mapper.Object);

        var bookResponse = await getBookByIdQueryHandler.Handle(getBookByIdQuery, new CancellationToken());

        Assert.NotNull(bookResponse);

        bookRepository.Verify(br => br.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()).Result, Times.Once);
    }
}
