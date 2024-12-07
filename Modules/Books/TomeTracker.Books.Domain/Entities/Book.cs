using TomeTracker.Common.Entities;

namespace TomeTracker.Books.Domain.Entities;

public class Book : Entity
{
    public Title Title { get; private set; }

    public Author Author { get; private set; }

    public Genre Genre { get; private set; }

    public Isbn Isbn { get; private set; }

    public PageCount PageCount { get; private set; }

    public PublicationYear PublicationYear { get; private set; }

    public NumberOfCopies NumberOfCopies { get; private set; }

    public Book(
        Title title,
        Author author,
        Genre genre,
        Isbn isbn,
        PageCount pageCount,
        PublicationYear publicationYear,
        NumberOfCopies numberOfCopies)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Isbn = isbn;
        PageCount = pageCount;
        PublicationYear = publicationYear;
        NumberOfCopies = numberOfCopies;
    }

    public void Update(
        Title title,
        Author author,
        Genre genre,
        Isbn isbn,
        PageCount pageCount,
        PublicationYear publicationYear,
        NumberOfCopies numberOfCopies)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Isbn = isbn;
        PageCount = pageCount;
        PublicationYear = publicationYear;
        NumberOfCopies = numberOfCopies;
    }
}
