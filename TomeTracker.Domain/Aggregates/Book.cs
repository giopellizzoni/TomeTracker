using TomeTracker.Common;

namespace TomeTracker.Domain.Entities;

public sealed class Book: BaseEntity
{
    public Book(string title,
        string author,
        string isbn,
        int publishingYear)
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

    public void Update(string title, string author, string isbn, int publishingYear)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        PublishingYear = publishingYear;
        UpdatedAt = DateTime.Now;
    }
}
