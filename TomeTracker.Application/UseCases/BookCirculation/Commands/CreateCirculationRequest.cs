using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.BookCirculation.Commands;

public sealed record CreateCirculationRequest(Guid IdUser, Guid IdBook) : IRequest<BookCirculationResponse>;
