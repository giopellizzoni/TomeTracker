using TomeTracker.Common;

namespace TomeTracker.Domain.Aggregates.Books;

public sealed class Book: AggregateRoot
{
    public Book(string title,
        string author,
        string isbn,
        int publishingYear) : base()
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        PublishingYear = publishingYear;
        CreatedAt = DateTime.Now;
    }

    public string Title { get; private set; }

    public string Author { get; private set; }

    public string Isbn { get; private set; }

    public int PublishingYear { get; private set; }
}
