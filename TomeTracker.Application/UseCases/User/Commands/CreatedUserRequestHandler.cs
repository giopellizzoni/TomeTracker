using MediatR;

using TomeTracker.Application.Models;

namespace TomeTracker.Application.UseCases.User.Commands;

public class CreatedUserRequestHandler: IRequestHandler<CreateUserRequest, UserResponse>
{
    public Task<UserResponse> Handle(
        CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
