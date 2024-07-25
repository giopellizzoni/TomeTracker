namespace TomeTracker.Common;

public class AggregateRoot : Entity<Guid>
{
    private readonly List<IEvent> _events = new ();

    public IList<IEvent> Events => _events;

    public void AddEvents(IEvent @event)
    {
        Events.Add(@event);
    }
}
