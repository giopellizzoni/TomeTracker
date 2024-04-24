using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.Book.Commands;

public sealed record CreateBookRequest(
    string Title,
    string Author,
    string ISBN,
    int PublishingYear) : IRequest<BookResponse>;
