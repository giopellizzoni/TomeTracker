using MediatR;

namespace TomeTracker.Application.UseCases.Book.Models;

public sealed record BookRequest(
    string Title,
    string Author,
    string ISBN,
    int PublishingYear) : IRequest<BookResponse>;
