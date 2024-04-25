using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.User.Commands;

public record UpdateUserRequest(Guid Id, string Email, string Name) : IRequest<UserResponse>;
