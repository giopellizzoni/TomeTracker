using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Queries;

public sealed class GetAllUsersRequestHandler : BaseHandler, IRequestHandler<GetAllUsersRequest, List<UserResponse>>
{
    public GetAllUsersRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<List<UserResponse>> Handle(
        GetAllUsersRequest request,
        CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.Users.GetAll(cancellationToken);

        return _mapper.Map<List<UserResponse>>(users);
    }
}
