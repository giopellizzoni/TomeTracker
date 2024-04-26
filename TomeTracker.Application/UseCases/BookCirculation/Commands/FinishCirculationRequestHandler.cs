using AutoMapper;

using MediatR;

using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.BookCirculation.Commands;

public class FinishCirculationRequestHandler: IRequestHandler<FinishCirculationRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public FinishCirculationRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
