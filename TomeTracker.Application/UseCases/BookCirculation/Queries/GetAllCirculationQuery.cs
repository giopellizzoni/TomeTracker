using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.BookCirculation.Queries;

public sealed record GetAllCirculationQuery : IRequest<List<BookCirculationResponse>>;
