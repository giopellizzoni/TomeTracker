using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.User.Commands;

public sealed record CreateUserRequest(string Email, string Name) : IRequest<UserResponse>;
