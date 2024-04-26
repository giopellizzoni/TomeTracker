using AutoMapper;

using MediatR;

using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Commands;

public class DeleteUserRequestHandler: IRequestHandler<DeleteUserRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(
        DeleteUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.Get(request.Id, cancellationToken);
        await _unitOfWork.BeginTransactionAsync();
        user?.Delete();
        await _unitOfWork.CommitTransactionAsync();
        return Unit.Value;
    }
}
