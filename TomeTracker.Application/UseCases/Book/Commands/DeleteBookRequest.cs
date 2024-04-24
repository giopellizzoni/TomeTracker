using MediatR;

namespace TomeTracker.Application.UseCases.Book.Commands;

public sealed record DeleteBookRequest(Guid Id): IRequest<Unit>;
