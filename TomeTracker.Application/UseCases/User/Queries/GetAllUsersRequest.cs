using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.User.Queries;

public sealed record GetAllUsersRequest : IRequest<List<UserResponse>>;
