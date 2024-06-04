using AutoMapper;

using MediatR;

using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Commands;

public class DeleteUserRequestHandler : BaseHandler, IRequestHandler<DeleteUserRequest, Unit>
{
    public DeleteUserRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<Unit> Handle(
        DeleteUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetById(request.Id, cancellationToken);
        await _unitOfWork.BeginTransactionAsync();
        user?.Delete();
        await _unitOfWork.CommitTransactionAsync();

        return Unit.Value;
    }
}
