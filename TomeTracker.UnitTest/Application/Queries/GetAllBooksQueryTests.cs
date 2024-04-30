using AutoMapper;

using Moq;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Book.Queries;
using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.UnitTest.Application.Queries;

public sealed class GetAllBooksQueryTests: BaseApplicationTests
{
    [Fact]
    public async Task GetAllBooks_Query_ReturnsAllBooksList()
    {
        var books = CreateBooks();
        var mapper = MakeMapper();
        var unityOfWork = MakeUnitOfWorkWith(MakeRepositoryWith(books));

        var getAllBooksQuery = new GetAllBooksQuery();
        var getAllBooksQueryHandler = new GetAllBooksQueryHandler(unityOfWork, mapper);

        var bookResponseList = await getAllBooksQueryHandler.Handle(getAllBooksQuery, new CancellationToken());

        Assert.Equal(3, bookResponseList.Count);
    }
}
