using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.BookCirculation.Queries;

public class GetCirculationByDateQueryHandler: IRequestHandler<GetCirculationByDateQuery, BookCirculationResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public async Task<BookCirculationResponse> Handle(
        GetCirculationByDateQuery request,
        CancellationToken cancellationToken)
    {
        var circulations = await _unitOfWork.Circulations.GetCirculation(request.circulationDate, cancellationToken);

        return _mapper.Map<BookCirculationResponse>(circulations);
    }
}
