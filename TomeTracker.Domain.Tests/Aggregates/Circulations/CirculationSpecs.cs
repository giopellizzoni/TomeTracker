using FluentAssertions;

using TomeTracker.Domain.Aggregates.Circulations;
using TomeTracker.Domain.Aggregates.Circulations.ValueObjects;

namespace TomeTracker.Domain.Tests.Aggregates.Circulations;

public class CirculationSpecs
{
    [Fact]
    public void Book_circulation_should_create_circulation_with_Non_empty_start()
    {
        var userId = UserId.Create(1);
        var bookId = BookId.Create(2);
        var circulation = new BookCirculation(userId, bookId);

        circulation.CirculationDate.StartDate.Should().NotBeBefore(DateTime.Today);
        circulation.CirculationDate.EndDate.Should().BeNull();
    }

    [Fact]
    public void Finish_circulation_should_register_end_circulation_date()
    {
        var userId = UserId.Create(1);
        var bookId = BookId.Create(2);
        var circulation = new BookCirculation(userId, bookId);
        var newDate = DateTime.Today.AddDays(3);

        circulation.EndCirculationOnDate(newDate);

        circulation.CirculationDate.EndDate.Should().NotBeNull();
    }

    [Fact]
    public void End_circulation_date_cannot_be_in_the_past()
    {
        var userId = UserId.Create(1);
        var bookId = BookId.Create(2);
        var circulation = new BookCirculation(userId, bookId);
        var newDate = DateTime.Today.AddDays(-1);

        Action action = () => circulation.EndCirculationOnDate(newDate);

        action.Should().Throw<ArgumentException>();
    }
    [Fact]
    public void End_circulation_date_cannot_be_equal_start_circulation_date()
    {
        var userId = UserId.Create(1);
        var bookId = BookId.Create(2);
        var circulation = new BookCirculation(userId, bookId);
        var newDate = DateTime.Today;

        Action action = () => circulation.EndCirculationOnDate(newDate);

        action.Should().Throw<ArgumentException>();
    }

}
