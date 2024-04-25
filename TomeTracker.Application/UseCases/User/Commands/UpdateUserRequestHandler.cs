using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Commands;

public class UpdateUserRequestHandler: IRequestHandler<UpdateUserRequest, UserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserRequestHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(
        UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.Get(request.Id, cancellationToken);
        await _unitOfWork.BeginTransactionAsync();

        user?.Update(request.Name, request.Email);
        await _unitOfWork.CommitTransactionAsync();

        return _mapper.Map<UserResponse>(user);
    }
}