using TomeTracker.Common;

namespace TomeTracker.Domain.Entities;

public sealed class BookCirculation : BaseEntity
{
    public BookCirculation(Guid idUser, Guid idBook)
    {
        IdUser = idUser;
        IdBook = idBook;
        CirculationDate = DateTime.Now;
    }

    public Guid IdUser { get; set; }
    public User? User { get; set; }
    public Guid IdBook { get; set; }
    public Book? Book { get; set; }
    public DateTime CirculationDate { get; set; }
}
