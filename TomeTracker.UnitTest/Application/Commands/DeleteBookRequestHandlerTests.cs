using AutoMapper;

using Moq;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Book.Commands;
using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.UnitTest.Application.Commands;

public sealed class DeleteBookRequestHandlerTests: BaseApplicationTests
{
    [Fact]
    public async Task DeleteBook_ValidId_ReturnsNoContent()
    {
        var book = CreateBook() ;
        var unityOfWork = MakeUnitOfWorkWith(MakeRepositoryWith(book));
        var mapper = MakeMapper();

        var deleteBookRequest = new DeleteBookRequest(book.Id);
        var deleteBookRequestHandler = new DeleteBookRequestHandler(unityOfWork, mapper);

        await deleteBookRequestHandler.Handle(deleteBookRequest, new CancellationToken());

        Assert.NotNull(book.DeletedAt);
    }
}
