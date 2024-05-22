using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Commands;

public class UpdateUserRequestHandler : BaseHandler, IRequestHandler<UpdateUserRequest, UserResponse>
{
    public UpdateUserRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<UserResponse> Handle(
        UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.Get(request.Id, cancellationToken);
        await _unitOfWork.BeginTransactionAsync();

        user?.Update(request.Name);
        await _unitOfWork.CommitTransactionAsync();

        return _mapper.Map<UserResponse>(user);
    }
}
