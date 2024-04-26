using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.BookCirculation.Queries;

public class GetAllCirculationQueryHandler: IRequestHandler<GetAllCirculationQuery, List<BookCirculationResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllCirculationQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<BookCirculationResponse>> Handle(
        GetAllCirculationQuery request,
        CancellationToken cancellationToken)
    {
        var circulations = await _unitOfWork.Circulations.GetAll(cancellationToken);

        return _mapper.Map<List<BookCirculationResponse>>(circulations);
    }
}
