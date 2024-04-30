using AutoMapper;

using Bogus;

using Moq;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Book.Commands;
using TomeTracker.Domain.Entities;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.UnitTest.Application;

public abstract class BaseApplicationTests
{
    private Faker _faker;

    protected Faker Faker => _faker ??= new Faker();

    protected Book CreateBook()
    {
        return new Book(
            Faker.Hacker.Phrase(),
            Faker.Name.FullName(),
            Faker.Random.ReplaceNumbers("##############"),
            Faker.Random.Int(1950, 2014)) { Id = Guid.NewGuid() };
    }

    protected List<Book> CreateBooks(int listSize = 3)
    {
        var books = new List<Book>();
        for (var i = 0; i < listSize; i++)
        {
            books.Add(CreateBook());
        }

        return books;
    }

    protected IBookRepository MakeRepositoryWith(Book book)
    {
        var bookRepository = new Mock<IBookRepository>();
        bookRepository.Setup(b => b.Get(It.IsAny<Guid>(), new CancellationToken())).ReturnsAsync(book);

        return bookRepository.Object;
    }

    protected IUnitOfWork MakeUnitOfWorkWith(IBookRepository bookRepository)
    {
        var unityOfWork = new Mock<IUnitOfWork>();
        unityOfWork.SetupGet(u => u.Books).Returns(bookRepository);

        return unityOfWork.Object;
    }

    protected IMapper MakeMapper()
    {
        return new Mapper(new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Book, BookResponse>();
                cfg.CreateMap<CreateBookRequest, Book>();
            }));
    }
}
