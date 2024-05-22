using TomeTracker.Application.UseCases.Book.Commands;

namespace TomeTracker.UnitTest.Application.Commands;

public sealed class CreateBookRequestHandlerTests: BookBaseApplicationTests
{
    [Fact]
    public async Task CreateBook_ValidData_ReturnsBook()
    {
        var book = CreateBook();
        var unityOfWork = MakeUnitOfWorkWith(MakeRepositoryWith(book));
        var mapper = MakeMapper();

        var createBookRequest = new CreateBookRequest(book.Title, book.Author, book.Isbn, book.PublishingYear);
        var createBooRequestHandler = new CreateBookRequestHandler(unityOfWork, mapper);

        var bookResponse = await createBooRequestHandler.Handle(createBookRequest, new CancellationToken());
        Assert.NotNull(bookResponse);
    }

}
