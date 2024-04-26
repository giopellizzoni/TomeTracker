using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.BookCirculation.Queries;

public class GetCirculationByIdQueryHandler: IRequestHandler<GetCirculationByIdQuery, BookCirculationResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public async Task<BookCirculationResponse> Handle(
        GetCirculationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var circulation = await _unitOfWork.Circulations.Get(request.Id, cancellationToken);

        return _mapper.Map<BookCirculationResponse>(circulation);
    }
}
