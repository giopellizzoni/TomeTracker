using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Commands;

public class CreateUserRequestHandler: BaseHandler, IRequestHandler<CreateUserRequest, UserResponse>
{

    public CreateUserRequestHandler(IUnitOfWork unitOfWork,
        IMapper mapper): base(unitOfWork, mapper)
    {
    }

    public async Task<UserResponse> Handle(
        CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Domain.Aggregates.Users.User>(request);
        await _unitOfWork.BeginTransactionAsync();
        _unitOfWork.Users.Create(user);
        await _unitOfWork.CommitTransactionAsync();

        return _mapper.Map<UserResponse>(user);
    }
}
