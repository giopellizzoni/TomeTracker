using AutoMapper;

using Moq;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Book.Commands;
using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.UnitTest.Application.Commands;

public sealed class UpdateBookRequestHandlerTests: BaseApplicationTests
{

    [Fact]
    public async Task UpdateBook_ValidData_ReturnsUpdatedBook()
    {
        var book = CreateBook();
        var unityOfWork = MakeUnitOfWorkWith(MakeRepositoryWith(book));
        var mapper = MakeMapper();

        var updateBookRequest = new UpdateBookRequest(book.Id, "New book Title", "New Author", "New ISBN", 1980);
        var updateBookRequestHandler = new UpdateBookRequestHandler(unityOfWork, mapper);

        var updatedBook = await updateBookRequestHandler.Handle(updateBookRequest, new CancellationToken());

        Assert.Equal(updateBookRequest.Id, updatedBook.Id);

    }

}
