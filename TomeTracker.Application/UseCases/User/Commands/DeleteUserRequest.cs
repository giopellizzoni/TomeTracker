using MediatR;

namespace TomeTracker.Application.UseCases.User.Commands;

public sealed record DeleteUserRequest(Guid Id) : IRequest<Unit>;
