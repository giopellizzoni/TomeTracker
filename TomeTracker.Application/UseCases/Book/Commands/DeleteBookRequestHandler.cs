using AutoMapper;

using MediatR;

using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Commands;

public sealed class DeleteBookRequestHandler : BaseHandler, IRequestHandler<DeleteBookRequest, Unit>
{
    public DeleteBookRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<Unit> Handle(
        DeleteBookRequest request,
        CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Books.Get(request.Id, cancellationToken);
        await _unitOfWork.BeginTransactionAsync();
        book?.Delete();
        await _unitOfWork.CommitTransactionAsync();

        return Unit.Value;
    }
}
