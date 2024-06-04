using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.Book.Queries;

public class GetBookByIdQuery: IRequest<BookResponse?>
{
    public GetBookByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
