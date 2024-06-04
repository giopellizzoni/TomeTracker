using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.BookCirculation.Commands;

public class CreateCirculationRequestHandler: BaseHandler, IRequestHandler<CreateCirculationRequest, BookCirculationResponse>
{
    public CreateCirculationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<BookCirculationResponse> Handle(
        CreateCirculationRequest request,
        CancellationToken cancellationToken)
    {
        var circulation = _mapper.Map<Domain.Aggregates.Circulations.BookCirculation>(request);
        await _unitOfWork.BeginTransactionAsync();
        _unitOfWork.Circulations.Create(circulation);
        await _unitOfWork.CommitTransactionAsync();

        return _mapper.Map<BookCirculationResponse>(circulation);
    }


}
