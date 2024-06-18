using TomeTracker.Common;
using TomeTracker.Domain.Aggregates.ValueObjects;

namespace TomeTracker.Domain.Aggregates.Books;

public sealed class Book: AggregateRoot
{
    public Book(BookTitle title,
        string author,
        string isbn,
        int publishingYear,
        int quantity)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        PublishingYear = publishingYear;
        Quantity = quantity;
        CreatedAt = DateTime.Now;

    }

    public BookTitle Title { get; private set; }

    public string Author { get; private set; }

    public string Isbn { get; private set; }

    public int PublishingYear { get; private set; }

    public int Quantity { get; private set; }


}
