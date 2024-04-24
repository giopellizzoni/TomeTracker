using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.Book.Queries;

public sealed class GetAllBooksQuery: IRequest<List<BookResponse>>
{
}
