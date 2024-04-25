using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.User.Queries;

public class GetUserByIdRequestHandler: IRequestHandler<GetUserByIdRequest, UserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdRequestHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(
        GetUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.Get(request.Id, cancellationToken);

        return _mapper.Map<UserResponse>(user);
    }
}
