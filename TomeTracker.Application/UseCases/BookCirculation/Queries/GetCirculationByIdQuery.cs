using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.BookCirculation.Queries;

public sealed record GetCirculationByIdQuery(Guid Id) : IRequest<BookCirculationResponse>;
