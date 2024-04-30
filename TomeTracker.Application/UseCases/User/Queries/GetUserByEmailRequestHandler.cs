using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Queries;

public sealed class GetUserByEmailRequestHandler : BaseHandler, IRequestHandler<GetUserByEmailRequest, UserResponse>
{
    public GetUserByEmailRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper): base(unitOfWork, mapper)
    {
    }

    public async Task<UserResponse> Handle(
        GetUserByEmailRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByEmail(request.Email, cancellationToken);

        return _mapper.Map<UserResponse>(user);
    }
}
