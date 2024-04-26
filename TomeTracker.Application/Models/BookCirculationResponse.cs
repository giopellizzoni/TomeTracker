namespace TomeTracker.Application.Models;

public sealed class BookCirculationResponse
{
    public Guid Id { get; set; }
    public Guid IdUser { get; set; }
    public Guid IdBook { get; set; }
    public DateTime CirculationDate { get; set; }
}
