using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Queries;

public sealed class GetAllUsersRequestHandler: IRequestHandler<GetAllUsersRequest, List<UserResponse>>
{
    private readonly IUnitOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public GetAllUsersRequestHandler(IUnitOfWork unityOfWork,
        IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<List<UserResponse>> Handle(
        GetAllUsersRequest request,
        CancellationToken cancellationToken)
    {
        var users = await _unityOfWork.Users.GetAll(cancellationToken);

        return _mapper.Map<List<UserResponse>>(users);
    }
}
