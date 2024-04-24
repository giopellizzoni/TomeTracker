using AutoMapper;

using Moq;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Book.Queries;
using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.UnitTest.Application.Queries;

public sealed class GetBookByIdQueryTests
{
    [Fact]
    public async Task GetBookById_CallingId_ReturnsBook()
    {
        var book = new Book("Book Title", "Book Author", "ISBN Number", 1950);

        var bookRepository = new Mock<IBookRepository>();
        bookRepository.Setup( b =>  b.Get(It.IsAny<Guid>(), new CancellationToken())).ReturnsAsync(book);

        var unityOfWork = new Mock<IUnitOfWork>();
        unityOfWork.SetupGet(u => u.Books).Returns(bookRepository.Object);

        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Book, BookResponse>()));

        var getBookByIdQuery = new GetBookByIdQuery(Guid.NewGuid());
        var getBookByIdQueryHandler = new GetBookByIdQueryHandler(unityOfWork.Object, mapper);

        var bookResponse = await getBookByIdQueryHandler.Handle(getBookByIdQuery, new CancellationToken());

        Assert.NotNull(bookResponse);

        bookRepository.Verify(br => br.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
