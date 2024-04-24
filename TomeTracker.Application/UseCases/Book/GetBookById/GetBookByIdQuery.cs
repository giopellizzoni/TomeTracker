using MediatR;
using TomeTracker.Application.UseCases.Book.Models;

namespace TomeTracker.Application.UseCases.Book.GetBookById;

public class GetBookByIdQuery: IRequest<BookResponse?>
{
    public GetBookByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
