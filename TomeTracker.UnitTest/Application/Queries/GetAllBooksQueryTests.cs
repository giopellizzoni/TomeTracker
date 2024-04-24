using AutoMapper;

using Moq;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Book.Queries;
using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.UnitTest.Application.Queries;

public sealed class GetAllBooksQueryTests
{
    [Fact]
    public async Task GetAllBooks_Query_ReturnsAllBooksList()
    {
        var books = new List<Book>
        {
            new("Book Title 1", "Book Author 1", "ISBN Number 1", 1950) { Id = Guid.NewGuid()},
            new("Book Title 2", "Book Author 2", "ISBN Number 2", 1951){ Id = Guid.NewGuid()},
            new("Book Title 3", "Book Author 3", "ISBN Number 3", 1952){ Id = Guid.NewGuid()}
        };

        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Book, BookResponse>()));

        var bookRepository = new Mock<IBookRepository>();
        bookRepository.Setup( b =>  b.GetAll(new CancellationToken())).ReturnsAsync(books);

        var unityOfWork = new Mock<IUnitOfWork>();
        unityOfWork.SetupGet(u => u.Books).Returns(bookRepository.Object);

        var getAllBooksQuery = new GetAllBooksQuery();
        var getAllBooksQueryHandler = new GetAllBooksQueryHandler(unityOfWork.Object, mapper);

        var bookResponseList = await getAllBooksQueryHandler.Handle(getAllBooksQuery, new CancellationToken());

        Assert.Equal(3, bookResponseList.Count);

        bookRepository.Verify(br => br.GetAll( It.IsAny<CancellationToken>()), Times.Once);
    }
}
