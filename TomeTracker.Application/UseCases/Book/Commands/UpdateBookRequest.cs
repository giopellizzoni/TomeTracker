using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.Book.Commands;

public sealed record UpdateBookRequest(
    Guid Id,
    string Title,
    string Author,
    string ISBN,
    int PublishingYear) : IRequest<BookResponse>;
