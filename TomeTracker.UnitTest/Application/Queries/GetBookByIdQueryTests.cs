using AutoMapper;

using Moq;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Book.Queries;
using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.UnitTest.Application.Queries;

public sealed class GetBookByIdQueryTests: BaseApplicationTests
{
    [Fact]
    public async Task GetBookById_CallingId_ReturnsBook()
    {
        var book = CreateBook();

        var unityOfWork = MakeUnitOfWorkWith(MakeRepositoryWith(book));

        var mapper = MakeMapper();

        var getBookByIdQuery = new GetBookByIdQuery(Guid.NewGuid());
        var getBookByIdQueryHandler = new GetBookByIdQueryHandler(unityOfWork, mapper);
        var bookResponse = await getBookByIdQueryHandler.Handle(getBookByIdQuery, new CancellationToken());
        Assert.NotNull(bookResponse);

    }
}
