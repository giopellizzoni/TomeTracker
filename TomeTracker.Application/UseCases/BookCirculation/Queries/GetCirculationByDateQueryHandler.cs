using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.BookCirculation.Queries;

public class GetCirculationByDateQueryHandler : BaseHandler, IRequestHandler<GetCirculationByDateQuery, BookCirculationResponse>
{
    public GetCirculationByDateQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<BookCirculationResponse> Handle(
        GetCirculationByDateQuery request,
        CancellationToken cancellationToken)
    {
        var circulations = await _unitOfWork.Circulations.GetCirculation(request.circulationDate, cancellationToken);

        return _mapper.Map<BookCirculationResponse>(circulations);
    }
}
