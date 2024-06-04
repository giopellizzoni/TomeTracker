using Ardalis.GuardClauses;

using TomeTracker.Common;

namespace TomeTracker.Domain.Aggregates.Circulations;

public class CirculationDate: ValueObject<CirculationDate>
{
    public DateTime StartDate { get; }
    public DateTime? EndDate { get; }

    private CirculationDate(DateTime startDate, DateTime? endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public static CirculationDate StartCirculation(DateTime startDate)
    {
        Guard.Against.Null(startDate);
        Guard.Against.Expression(date => date < DateTime.Today, startDate, nameof(startDate));
        return new CirculationDate(startDate, null);
    }

    public CirculationDate FinishCirculation(DateTime? endDate)
    {
        Guard.Against.Null(endDate);
        Guard.Against.Expression(date => date < StartDate, endDate.Value, nameof(endDate));
        Guard.Against.Expression(date => date == DateTime.Today, endDate.Value, nameof(endDate));

        var newDate = new CirculationDate(StartDate, endDate);
        if (IsSunday(newDate))
        {
            FinishCirculation(endDate.Value.AddDays(1));
        }
        return newDate;
    }

    private bool IsSunday(CirculationDate date)
    {
        Guard.Against.Null(date.EndDate);
        return date.EndDate.Value.DayOfWeek != DayOfWeek.Sunday;

    }

}
