using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Queries;

public sealed class GetUserByEmailRequestHandler: IRequestHandler<GetUserByEmailRequest, UserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByEmailRequestHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(
        GetUserByEmailRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByEmail(request.Email, cancellationToken);

        return _mapper.Map<UserResponse>(user);
    }
}
