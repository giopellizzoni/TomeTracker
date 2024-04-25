using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.User.Queries;

public record GetUserByIdRequest(Guid Id) : IRequest<UserResponse>;
