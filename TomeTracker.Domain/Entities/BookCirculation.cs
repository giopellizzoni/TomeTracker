using TomeTracker.Domain.Common;

namespace TomeTracker.Domain.Entities;

public class BookCirculation : BaseEntity
{

    public Guid IdUser { get; set; }

    public User? User { get; set; }

    public Guid IdBook { get; set; }

    public Book? Book { get; set; }

    public DateTime CirculationDate { get; set; }

}
