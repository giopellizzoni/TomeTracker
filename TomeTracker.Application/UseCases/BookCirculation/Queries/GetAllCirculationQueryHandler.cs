using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.BookCirculation.Queries;

public class GetAllCirculationQueryHandler: BaseHandler, IRequestHandler<GetAllCirculationQuery, List<BookCirculationResponse>>
{

    public GetAllCirculationQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper): base(unitOfWork, mapper)
    {
    }

    public async Task<List<BookCirculationResponse>> Handle(
        GetAllCirculationQuery request,
        CancellationToken cancellationToken)
    {
        var circulations = await _unitOfWork.Circulations.GetAll(cancellationToken);

        return _mapper.Map<List<BookCirculationResponse>>(circulations);
    }
}
