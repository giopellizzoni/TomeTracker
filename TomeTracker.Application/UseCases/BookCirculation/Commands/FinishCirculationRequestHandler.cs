using AutoMapper;

using MediatR;

using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.BookCirculation.Commands;

public class FinishCirculationRequestHandler: BaseHandler, IRequestHandler<FinishCirculationRequest, Unit>
{
    public FinishCirculationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }

    public async Task<Unit> Handle(
        FinishCirculationRequest request,
        CancellationToken cancellationToken)
    {
        var circulation = await _unitOfWork.Circulations.Get(request.Id, cancellationToken);
        await _unitOfWork.BeginTransactionAsync();
        circulation?.Delete();
        await _unitOfWork.CommitTransactionAsync();

        return Unit.Value;
    }
}
