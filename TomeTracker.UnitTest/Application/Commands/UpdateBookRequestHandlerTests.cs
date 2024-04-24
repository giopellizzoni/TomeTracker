using AutoMapper;

using Moq;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Book.Commands;
using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.UnitTest.Application.Commands;

public sealed class UpdateBookRequestHandlerTests
{

    [Fact]
    public async Task UpdateBook_ValidData_ReturnsUpdatedBook()
    {
        var book = new Book("Book Title", "Book Author", "ISBN Number", 1950) { Id = Guid.NewGuid() };

        var bookRepository = new Mock<IBookRepository>();
        bookRepository.Setup( b =>  b.Get(It.IsAny<Guid>(), new CancellationToken())).ReturnsAsync(book);

        var unityOfWork = new Mock<IUnitOfWork>();
        unityOfWork.SetupGet(u => u.Books).Returns(bookRepository.Object);

        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Book, BookResponse>()));

        var updateBookRequest = new UpdateBookRequest(book.Id, "New book Title", "New Author", "New ISBN", 1980);
        var updateBookRequestHandler = new UpdateBookRequestHandler(unityOfWork.Object, mapper);

        var updatedBook = await updateBookRequestHandler.Handle(updateBookRequest, new CancellationToken());

        Assert.Equal(updateBookRequest.Id, updatedBook.Id);

    }

}
