using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Queries;

public class GetUserByIdRequestHandler: BaseHandler, IRequestHandler<GetUserByIdRequest, UserResponse>
{
    public GetUserByIdRequestHandler(IUnitOfWork unitOfWork,
        IMapper mapper): base(unitOfWork, mapper)
    {
    }

    public async Task<UserResponse> Handle(
        GetUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.Get(request.Id, cancellationToken);

        return _mapper.Map<UserResponse>(user);
    }
}
