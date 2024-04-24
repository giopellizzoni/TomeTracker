using MediatR;

using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Commands;

public sealed class DeleteBookRequestHandler: IRequestHandler<DeleteBookRequest, Unit>
{
    private readonly IUnityOfWork _unityOfWork;

    public DeleteBookRequestHandler(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }

    public async Task<Unit> Handle(
        DeleteBookRequest request,
        CancellationToken cancellationToken)
    {
        var book = await _unityOfWork.Books.Get(request.Id, cancellationToken);
        await _unityOfWork.BeginTransactionAsync();
        book?.Delete();
        await _unityOfWork.SaveChangesAsync();
        await _unityOfWork.CommitTransactionAsync();

        return Unit.Value;
    }
}
