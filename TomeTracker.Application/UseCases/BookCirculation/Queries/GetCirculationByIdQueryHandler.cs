using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.BookCirculation.Queries;

public class GetCirculationByIdQueryHandler : BaseHandler, IRequestHandler<GetCirculationByIdQuery, BookCirculationResponse>
{
    public GetCirculationByIdQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<BookCirculationResponse> Handle(
        GetCirculationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var circulation = await _unitOfWork.Circulations.GetById(request.Id, cancellationToken);

        return _mapper.Map<BookCirculationResponse>(circulation);
    }
}
