using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.User.Queries;

public sealed record GetUserByEmailRequest(string Email) : IRequest<UserResponse>;
