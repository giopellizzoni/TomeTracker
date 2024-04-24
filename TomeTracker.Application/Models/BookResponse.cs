namespace TomeTracker.Application.Models;

public sealed record BookResponse
{
    public Guid Id { get; set; }
    public string Title { get;  set; }
    public string Author { get;  set; }
    public string Isbn { get;  set; }
    public int PublishingYear { get; set; }
}
