using MediatR;

using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Commands;

public sealed class DeleteBookRequestHandler: IRequestHandler<DeleteBookRequest, Unit>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteBookRequestHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(
        DeleteBookRequest request,
        CancellationToken cancellationToken)
    {
        var book = await unitOfWork.Books.Get(request.Id, cancellationToken);
        await unitOfWork.BeginTransactionAsync();
        book?.Delete();
        await unitOfWork.CommitTransactionAsync();

        return Unit.Value;
    }
}
