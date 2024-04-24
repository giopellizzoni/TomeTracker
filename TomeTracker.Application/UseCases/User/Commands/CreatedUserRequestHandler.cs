using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Commands;

public class CreatedUserRequestHandler: IRequestHandler<CreateUserRequest, UserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatedUserRequestHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(
        CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Domain.Entities.User>(request);
        await _unitOfWork.BeginTransactionAsync();
        _unitOfWork.Users.Create(user);
        await _unitOfWork.CommitTransactionAsync();

        return _mapper.Map<UserResponse>(user);
    }
}
