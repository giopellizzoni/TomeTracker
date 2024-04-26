using MediatR;

namespace TomeTracker.Application.UseCases.BookCirculation.Commands;

public sealed record FinishCirculationRequest(Guid Id) : IRequest<Unit>;
